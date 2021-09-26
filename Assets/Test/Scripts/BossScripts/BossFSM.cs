using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public class BossProperties
{
    public float flashInterval;
    
    

}

public enum BossStateType
{
    idel,attack,attack2,flash,walk,
}


public class BossFSM : MonoBehaviour
{
    public Animator Animator;
    //内部维护了一个状态
    public IBossState curState;

    public SpriteRenderer spriteRenderer;
    
    
    //通过字典进行转换
    private Dictionary<BossStateType, IBossState> AllStates = new Dictionary<BossStateType, IBossState>();

    public GameObject target;
    
    public BossProperties roleProperties;
    
    private void Start()
    {
         AllStates.Add(BossStateType.idel,new BossIdelState(this));
         AllStates.Add(BossStateType.flash,new BossFlashState(this));
         AllStates.Add(BossStateType.attack,new BossAttackState(this));
         AllStates.Add(BossStateType.attack2,new BossAttack2State(this));
         AllStates.Add(BossStateType.walk,new BossWalkState(this));

         Transition(BossStateType.idel);


         spriteRenderer = GetComponent<SpriteRenderer>();

    }
    
    public void Transition(BossStateType state)  //参数是枚举而不是IPlayerState，要通过字典来读
    {
        if (curState != null)
        {
            curState.OnExit();
        }

        curState = AllStates[state];
        curState.OnEnter();
    }
    
    private void Update()
    {
        curState.OnUpdate();
        
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void OnDisapper()
    {
        Transition(BossStateType.flash);
    }

    public void OnApperFinsh()
    {
        Transition(BossStateType.idel);
    }

    public float GetDistance()
    {
        return 0;
    }
    
}
