using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



namespace PlayerState
{
    [Serializable]
    public class RoleProperties
    {
        public float moveSpeed;
        public float jumpSpeedX;
        public float jumpSpeedY;
        public float airAttack3Force;

        public float slideSpeed;
        
        public float attackInterval;
        public float attackAirInterval;
    }
    
    public enum StateType
    {
        idel,run,jump,fall,attack,hurt,death,airAttack,slide
    }

    
    
    
    public class PlayerFSM : MonoBehaviour
    {
        public Animator Animator;
        //内部维护了一个状态
        public IPlayerState curState;

        public RoleProperties roleProperties;
        
        public bool IsGround;
        public bool IsAttack;
        public bool IsJump2;
        public float IsRight;
        public bool CanInput = true;
        
        public LayerMask layer;
        
        //通过字典进行转换
        private Dictionary<StateType, IPlayerState> AllStates = new Dictionary<StateType, IPlayerState>();
        
        

        public float InputX;
        public float InputY;
        
        private void Start()
        {
            AllStates.Add(StateType.idel,new IdelState(this));
            AllStates.Add(StateType.run,new RunState(this));
            AllStates.Add(StateType.jump,new AirState(this));
            AllStates.Add(StateType.fall,new FallState(this));
            AllStates.Add(StateType.attack,new AttackState(this));
            AllStates.Add(StateType.airAttack,new AirAttackState(this) );
            AllStates.Add(StateType.slide,new SlideState(this));

            Transition(StateType.idel);
        }


        public void Transition(StateType state)  //参数是枚举而不是IPlayerState，要通过字典来读
        {
            if (curState != null)
            {
                curState.OnExit();
            }

            curState = AllStates[state];
            curState.OnEnter();
        }
        
        
        private void Update()
        {
            curState.OnUpdate();

            if (CanInput)
            {
                PlayerInput();
            }
            
            PlayerDetect();
        }

        
        //玩家检测(是否在地面，受伤) anystate
        private void PlayerDetect()
        {
            IsGround = Physics2D.OverlapCircle(transform.position, 0.2f, layer);
            IsRight = gameObject.transform.localScale.x;

        }
        
        
        
        //玩家输入
        private void PlayerInput()
        {
            InputX = Mathf.Floor(Input.GetAxisRaw("Horizontal"));
            InputY = Mathf.Floor(Input.GetAxisRaw("Vertical"));
            
            Flip();
        }
        
        public int Flip()
        {
            if (InputX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                return -1;
            }
        
             if (InputX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                return 1;
            }

             return 1;
        }

        public void AttackOver()
        {
            IsAttack = false;
        }

        public void Jump2Over()
        {
            IsJump2 = false;
        }
        
        
    }
    
    
   


   





}

