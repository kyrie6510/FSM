using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class BossFlashState : IBossState
{
    private BossFSM _fsm;
    private Animator _animator;

    private AnimatorStateInfo aniInfo;
    
    private float timer;
    
    public BossFlashState(BossFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    public void OnEnter()
    {
       _animator.Play("BossDisappear");
       timer = _fsm.roleProperties.flashInterval;
       aniInfo = _animator.GetCurrentAnimatorStateInfo(0);
    }

    public void OnUpdate()
    {
        // if (timer != 0)
        // {
        //     timer -= Time.deltaTime;
        //     if (timer <= 0)
        //     {
        //         timer = 0;
        //         _fsm.Transition(BossStateType.idel);
        //     }
        // }

        if (aniInfo.normalizedTime >= 1.0f)
        {

            _fsm.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // StartCoroutine(ApperPlayerAround());
            ApperPlayerAround();
        }
        
    }

    

    public void OnExit()
    {
        
    }

    
    void ApperPlayerAround()
    {
        //计算生成位置
        Vector2 playerPos = _fsm.target.transform.position;
        float randomValue = Random.Range(-20, 20);
        _fsm.transform.position = playerPos + new Vector2(randomValue, 2);
        
        //在生成位置出现
        _fsm.gameObject.GetComponent<SpriteRenderer>().enabled = true; 
        // _animator.Play("BossAppear");
         _fsm.Transition(BossStateType.idel);

    }
    
    
}
