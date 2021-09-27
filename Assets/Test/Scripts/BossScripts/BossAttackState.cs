using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : IBossState
{
    private BossFSM _fsm;
    private Animator _animator;
    
    public BossAttackState(BossFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    
    
    public void OnEnter()
    {
        _animator.Play("BossAttack");
    }

    public void OnUpdate()
    {
        
    }

    public void OnExit()
    {
    
    }
}
