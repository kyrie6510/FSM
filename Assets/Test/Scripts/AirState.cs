using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState;
//玩家跳跃状态
public class AirState: IPlayerState
{
    public AirState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
    private PlayerFSM _fsm;
    private Animator _animator;
    private Rigidbody2D rig;
    
   
    
    
    public void OnEnter()
    {
        _animator.Play("PlayerJump");
        
        rig = _fsm.gameObject.GetComponent<Rigidbody2D>();
        rig.velocity = new Vector2(_fsm.roleProperties.jumpSpeedX*_fsm.InputX, _fsm.roleProperties.jumpSpeedY);
    }

    public void OnUpdate()
    {
        //二段跳
        if (Input.GetKeyDown(KeyCode.K)&&!_fsm.IsJump2)
        {
            _animator.Play("PlayerJump2");
            _fsm.IsJump2 = true;
            rig.velocity = new Vector2(_fsm.roleProperties.jumpSpeedX*_fsm.InputX, _fsm.roleProperties.jumpSpeedY);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            _fsm.Transition(StateType.airAttack);
        }
        
        
        if (rig.velocity.y <= 0.25f)
        {
            _fsm.Transition(StateType.fall);
        }
    }

    public void OnExit()
    {
        
    }
}
