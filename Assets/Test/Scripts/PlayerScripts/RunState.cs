using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState;
//玩家跑动状态
public class RunState: IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public RunState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
        
        
    public void OnEnter()
    {
        _animator.Play("PlayerRun");
        _rigidbody = _fsm.GetComponent<Rigidbody2D>();
    }

    public void OnUpdate()
    {

        if (_fsm.IsGround)
        {
            if (_fsm.InputX != 0)
            {
                _rigidbody.velocity = new Vector2( _fsm.InputX * _fsm.roleProperties.moveSpeed, _rigidbody.velocity.y);
            }
        
            else
            {
                _fsm.Transition(StateType.idel);
            }
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                _fsm.Transition(StateType.attack);
            }
        
            if (Input.GetKeyDown(KeyCode.K))
            {
                _fsm.Transition(StateType.jump);
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                _fsm.Transition(StateType.slide);
            }
        }

        else
        {
            _fsm.Transition(StateType.fall);
        }
        
        
        
       
        
    }

   
    
    
    
    
    public void OnExit()
    {
         _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}