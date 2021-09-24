using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack2State : IBossState
{
    
    private BossFSM _fsm;
    private Animator _animator;
    
    public BossAttack2State(BossFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    public void OnEnter()
    {
        _animator.Play("BossAttack2");
    }

    public void OnUpdate()
    {
      
    }

    public void OnExit()
    {
       
    }
}
