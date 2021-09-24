using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState;
//玩家跳跃状态
public class FallState: IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;

    private Rigidbody2D _rig;

    private float _timer;
    
    public FallState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
        
        
        
    public void OnEnter()
    {
        _animator.Play("PlayerFall");
        _rig = _fsm.GetComponent<Rigidbody2D>();
        //打开重力
        _rig.simulated = true;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void OnUpdate()
    {
        if (_rig.velocity.y == 0)
        {
            _fsm.Transition(StateType.idel);
        }
        else
        {
            _rig.velocity = new Vector2(_rig.velocity.x, _rig.velocity.y);
        }
        
        
        if (Input.GetKeyDown(KeyCode.K)&&!_fsm.IsJump2)
        {
            _fsm.IsJump2 = true;
            _animator.Play("PlayerJump2");
            _rig.velocity = new Vector2(_fsm.roleProperties.jumpSpeedX*_fsm.InputX, _fsm.roleProperties.jumpSpeedY);
        }


        if (Input.GetKeyDown(KeyCode.J))
        {
            _fsm.Transition(StateType.airAttack);
        }
        
        
        
    }

    public void OnExit()
    {
        _fsm.IsJump2 = false;
        _rig.velocity = Vector2.one;
    }
}