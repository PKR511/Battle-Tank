using Battle_Tank.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Helper.Interface.IDamageable;
using UnityEngine.AI;
using Battle_Tank.Tanks.AI;

namespace Battle_Tank.Tanks.Enemy
{
    /// <summary>
    /// Tank view.
    ///	For Applying Any Visual Changes To Game Object 
    /// </summary>
    public class EnemyTankView : MonoBehaviour,IDamageable
    {

        //private Variable
        private Rigidbody myBody;
        private EnemyTankController tankController;
       
        private AIStateType currentStateType = AIStateType.Idle;
        private AIState currentState;
        protected Dictionary<AIStateType, AIState> _states = new Dictionary<AIStateType, AIState>();
        private Collider t;
        //public 
        public AITargetType targetType = AITargetType.None;
        public Vector3 targetPos;
        public float attackDistance = 0;
        public float attackDuration = 0;
        //Method Defination

        /// <summary>
        /// Awake is called first when game object is invoked and is been used for initialization.
        /// </summary>
        void Awake()
        {
            Debug.Log("Tank View Awake");

            myBody = gameObject.GetComponent<Rigidbody>();
           
          
          
            // Fetch all states on this game object
            AIState[] states = GetComponents<AIState>();

            // Loop through all states and add them to the state dictionary
            foreach (AIState state in states)
            {
                if (state != null && !_states.ContainsKey(state.GetStateType()))
                {
                    // Add this state to the state dictionary
                    _states[state.GetStateType()] = state;

                   
                }
            }

            // Set the current state
            if (_states.ContainsKey(currentStateType))
            {
                currentState = _states[currentStateType];
                currentState.OnEnterState();
            }
            else
            {
                currentState = null;
            }

           
        }
        //Awake


        protected virtual void Update()
        {
            if (t != null)
            {
                if(t.gameObject.active==false)
                {
                    targetType = AITargetType.None;
                }
            }
            SetStates();
           // Debug.Log("Current State=" + currentState);
        }

        public void SetStates()
        {
            if (currentState == null) return;

            AIStateType newStateType = currentState.OnUpdate();
            if (newStateType != currentStateType)
            {
                AIState newState = null;
                if (_states.TryGetValue(newStateType, out newState))
                {
                    currentState.OnExitState();
                    newState.OnEnterState();
                    currentState = newState;
                }
                else
                if (_states.TryGetValue(AIStateType.Idle, out newState))
                {
                    currentState.OnExitState();
                    newState.OnEnterState();
                    currentState = newState;
                }

                currentStateType = newStateType;
            }
        }
        /// <summary>
        /// Initialize the specified tankController.
        /// </summary>
        /// <param name="tankController">Tank controller.</param>
        public void Initialize(EnemyTankController tankController)
        {
            this.tankController = tankController;
        }
        //Initialize

        /// <summary>
        /// Returns The Linked Controller
        /// </summary>
        /// <returns></returns>
        public EnemyTankController GetController()
        {
            return this.tankController;
        }//GetController



        public void OnTriggerEnter(Collider target)
        {
            if (target.tag == MyTags.PLAYER_TAG)
            {
                targetPos = target.gameObject.transform.position;
                RotateEnemyToward(targetPos);
                targetType = AITargetType.Player;
                t = target;
                Debug.Log("iisngoishgoisgoisgosgoshgoishgoisghsoighsoghsoi");
                //coroutine = StartCoroutine(Attack(attackDuration));
            }

        }//OnTriggerEnter

        public void OnTriggerStay(Collider target)
        {
            if (target.tag == MyTags.PLAYER_TAG)
            {
                
                    targetPos = target.gameObject.transform.position;
                    RotateEnemyToward(targetPos);
                    targetType = AITargetType.Player;
              
            }


        }//OnTriggerEnter




        public void OnTriggerExit(Collider target)
        {
            if (target.tag == MyTags.PLAYER_TAG)
            {
               
                targetType = AITargetType.Waypoint;
               
            }

        }//OnTriggerEnter

        private void RotateEnemyToward(Vector3 pos)
        {
            Vector3 lookVector = pos - this.transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }//RotateEnemyToward

      
             
        void IDamageable.TakeDamage(float damageAmount, string damageBy)
        {
            if(damageBy!=MyTags.ENEMY_TAG)
            this.tankController.ApplyDamage(damageAmount);
        }


        public void DestroyAll()
        {
            targetType = AITargetType.None;
            // StopAllCoroutines();
            Destroy(this);

            Debug.Log(gameObject + ":Killed");


        }

    } //Class
}
//namespace
