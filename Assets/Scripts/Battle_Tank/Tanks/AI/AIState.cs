using UnityEngine;
using System.Collections;
using Battle_Tank.Tanks.Enemy;

namespace Battle_Tank.Tanks.AI
{

    public enum AIStateType { None, Idle,  Patrol, Attack,  Pursuit, Dead }
    public enum AITargetType { None, Waypoint, Player }

    // ----------------------------------------------------------------------
    // Class	:	AIState
    // Desc		:	The base class of all AI States used by our AI System.
    // ----------------------------------------------------------------------
    public abstract class AIState : MonoBehaviour
    {
        protected EnemyTankView tankView;
       // protected AITargetType targetType = AITargetType.None;
        private void Awake()
        {
            tankView = GetComponent<EnemyTankView>();
        }

        // Default Handlers
        public virtual void OnEnterState() {
            this.enabled = true;
        }
        public virtual void OnExitState() {
            this.enabled = false;

        }



        // Abtract Methods
        public abstract AIStateType GetStateType();
        public abstract AIStateType OnUpdate();




      
    }//class
}//namespace