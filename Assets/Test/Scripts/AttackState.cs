using System.Collections;
using System.Collections.Generic;
using PlayerState;
using UnityEngine;

public class AttackState : IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;
        
    private int _comboStep = 1;
    private float timer;
        
    public AttackState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
        this.timer  = _fsm.roleProperties.attackInterval;
        
    }
        
    public void OnEnter()
    {
        _animator.Play("PlayerAttack"+_comboStep);
        _fsm.IsAttack = true;
        timer = _fsm.roleProperties.attackInterval;

        //关闭wasd输入
        _fsm.CanInput = false;

    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J)&&!_fsm.IsAttack)
        {
            _fsm.IsAttack = true;
            _comboStep++;
            this.OnEnter();
            if (_comboStep > 3)
            {
                _comboStep = 1;
            }
        }
        
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                _comboStep = 1;
                _fsm.Transition(StateType.idel);
            }
        }
        
    }

    public void OnExit()
    {
       
    }
        
}