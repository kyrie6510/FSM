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
        AppearPlayerAround();
        _animator.Play("BossAppear");
    }

    public void OnUpdate()
    {
        _fsm.OnAnimationFinshTransition(BossStateType.idel);
    }

    

    public void OnExit()
    {
        
    }


    void AppearPlayerAround()
    {
        //计算生成位置
        Vector2 playerPos = _fsm.target.transform.position;
        float randomValue = Random.Range(-1, 1);
        _fsm.transform.position = playerPos + new Vector2(randomValue, 2);

        _fsm.spriteRenderer.flipX = playerPos.x > _fsm.transform.position.x;
        
        //在生成位置出现
        _fsm.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
