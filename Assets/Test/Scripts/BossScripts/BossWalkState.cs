using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalkState : IBossState
{
    
    private BossFSM _fsm;
    private Animator _animator;
    
    public BossWalkState(BossFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    public void OnEnter()
    {
        _animator.Play("BossWalk");
        
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
        
    }
}
