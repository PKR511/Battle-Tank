using Battle_Tank.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Battle_Tank.Tanks.AI
{

    public class AITankState_Pursuit1 : AIState
    {
        private NavMeshAgent navAgent;
        private Coroutine coroutine;
        [SerializeField]
        private float StoppingDistance = 0;
        public override AIStateType GetStateType()
        {
            return AIStateType.Pursuit;
        }


        public override void OnEnterState()
        {
            base.OnEnterState();
            navAgent = GetComponent<NavMeshAgent>();
           
        }
        public override void OnExitState()
        {
            base.OnExitState();
            navAgent.isStopped=true;

        }

        public override AIStateType OnUpdate()
        {
            if (tankView.targetType == AITargetType.None)
            {
                return AIStateType.Idle;
            }

            if (tankView.targetType == AITargetType.Waypoint)
            {
                return AIStateType.Patrol;
            }
            if (tankView.targetType == AITargetType.Player)
            {


                SetTarget();
                if (Vector3.Distance(tankView.targetPos, transform.position) <= tankView.attackDistance)
                {
                    // currentStateType = AIStateType.Attack;
                    return AIStateType.Attack;
                }
                return AIStateType.Pursuit;
            }
            if (tankView.GetController().TankModel.Health <= 0)
            {
                return AIStateType.Dead;
            }
            return AIStateType.Pursuit;
            
        }


        public void SetTarget()
        {
            if (tankView.targetPos != null)
            {
                navAgent.SetDestination(tankView.targetPos);
               // navAgent.speed = tankView.GetController().TankModel.Speed;
            }
        }


    }
}//namespace