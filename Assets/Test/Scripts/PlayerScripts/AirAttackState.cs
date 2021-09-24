using System.Collections;
using System.Collections.Generic;
using PlayerState;
using UnityEngine;

public class AirAttackState : IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;
    private int _comboStep = 1;
    private float timer;
    private Rigidbody2D _rig;
    public AirAttackState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
        
    }
    
    
    public void OnEnter()
    {
        _animator.Play("PlayerAirAttack"+_comboStep);
        _fsm.IsAttack = true;
        timer = _fsm.roleProperties.attackAirInterval;
        
        _rig = _fsm.gameObject.GetComponent<Rigidbody2D>();
        
        
        
        //关闭wasd输入
        _fsm.CanInput = false;
        //关闭角色重力,清空速度
        _rig.velocity = Vector2.zero;
        _rig.simulated = false;
        
    }

    public void OnUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.J)&&!_fsm.IsAttack)
        {
            timer = _fsm.roleProperties.attackAirInterval;
            
            _fsm.IsAttack = true;
            _comboStep++;
            _animator.Play("PlayerAirAttack"+_comboStep);

            if (_comboStep == 3)
            {
                _rig.simulated = true;
                _rig.velocity = new Vector2(0, _fsm.roleProperties.airAttack3Force);
            }
            
            
            
            else if (_comboStep > 3)
            {
                _comboStep = 1;
            }
        }

        Debug.Log("timer"+timer);
        
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                _comboStep = 1;
                _fsm.Transition(StateType.fall);
                
            }
        }
        
    }

    public void OnExit()
    {
        
    }
}
