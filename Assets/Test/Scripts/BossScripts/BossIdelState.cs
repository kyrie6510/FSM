﻿using System.Collections;
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
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                _animator.Play("BossDisappear");
            }
        }
        
        Debug.Log("timer"+timer);
        
        
    }

    public void OnExit()
    {
        
    }
}
