using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdelState : IBossState
{
    
    private BossFSM _fsm;
    private Animator _animator;

    private float timer;
    
    public BossIdelState(BossFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    
    public void OnEnter()
    {
        _animator.Play("BossIdel");
        timer = _fsm.roleProperties.flashInterval;
    }

    public void OnUpdate()
    {
        
        if(_fsm.IsInAttackArea())
        {
            _fsm.Transition(BossStateType.attack);
        }
        
        
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            else
            {
                _animator.Play("BossDisappear");
                _fsm.OnAnimationFinshTransition(BossStateType.flash);
            }
            
        }
        
        
    }

    public void OnExit()
    {
        
    }
    
    
    
    
}
