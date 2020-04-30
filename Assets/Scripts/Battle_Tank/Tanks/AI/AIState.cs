using UnityEngine;
using System.Collections;


namespace Battle_Tank.Tanks.AI
{

    public enum AIStateType { None, Idle,  Patrol, Attack,  Pursuit, Dead }
    public enum AITargetType { None, Waypoint, Visual_Player }

    // ----------------------------------------------------------------------
    // Class	:	AIState
    // Desc		:	The base class of all AI States used by our AI System.
    // ----------------------------------------------------------------------
    public abstract class AIState : MonoBehaviour
    {
        private TankView tankView;
        private void Awake()
        {
            tankView = GetComponent<TankView>();
        }

        // Default Handlers
        public virtual void OnEnterState() { }
        public virtual void OnExitState() { }



        // Abtract Methods
        public abstract AIStateType GetStateType();
        public abstract AIStateType OnUpdate();




      
    }//class
}//namespace