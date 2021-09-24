using System.Collections;
using System.Collections.Generic;
using PlayerState;
using UnityEditor;
using UnityEngine;

public class SlideState : IPlayerState
{
    private PlayerFSM _fsm;
    private Animator _animator;
    private ClipAnimationInfoCurve aniInfo; 
    private Rigidbody2D _rig;

    private float _timer;
    
    public SlideState(PlayerFSM FSM)
    {
        this._fsm = FSM;
        this._animator = FSM.Animator;
        _rig = FSM.GetComponent<Rigidbody2D>();
        aniInfo = new ClipAnimationInfoCurve();
    }


    public void OnEnter()
    {
        
        _animator.Play("PlayerSlide");
        _rig.velocity = new Vector2(_fsm.IsRight* _fsm.roleProperties.slideSpeed, 0);
        _fsm.CanInput = false;
    }

    public void OnUpdate()
    {
        if (_fsm.IsGround)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _fsm.Transition(StateType.jump);
            }
        
        
            if (Mathf.Abs(_rig.velocity.x) < 0.25f)
            {
                _fsm.Transition(StateType.idel);
            }
        }

        else
        {
            _fsm.Transition(StateType.fall);
        }
        
    }

    public void OnExit()
    {
         // _animator.
    }
}
