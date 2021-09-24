using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState;
//玩家站立状态
public class IdelState : IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;
    public IdelState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
    }
        
    public void OnEnter()
    {
        _animator.Play("PlayerIdel");
        
        //打开wasd输入
        _fsm.CanInput = true;
    }

    public void OnUpdate()
    {
        if (_fsm.IsGround)
        {
            bool IsInput = _fsm.InputX != 0;
            if (IsInput)
            {
                _fsm.Transition(StateType.run);
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
        
        
        
        
    }

    public void OnExit()
    {
            
    }
}


