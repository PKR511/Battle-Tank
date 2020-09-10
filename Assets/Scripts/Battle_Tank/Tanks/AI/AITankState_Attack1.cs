using Battle_Tank.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Battle_Tank.Tanks.AI
{

    public class AITankState_Attack1 : AIState
    {
        private NavMeshAgent navAgent;
        private Coroutine coroutine;
        private Vector3 BulletSpwanPos;
        public override AIStateType GetStateType()
        {
            return AIStateType.Attack;
        }


        public override void OnEnterState()
        {
            base.OnEnterState();
            navAgent = GetComponent<NavMeshAgent>();
            coroutine = StartCoroutine(Attack(tankView.attackDuration));
        }

     
        public override void OnExitState()
        {
            base.OnExitState();
            navAgent = null;
            StopCoroutine(coroutine);

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
                if (Vector3.Distance(tankView.targetPos, transform.position) >= tankView.attackDistance)
                {
                    // currentStateType = AIStateType.Attack;
                    return AIStateType.Pursuit;
                }

                return AIStateType.Attack;
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
        public void StopShooting()
        {
            StopCoroutine(coroutine);
        }





        public IEnumerator Attack(float time)
        {
            while (true)
            {

                yield return new WaitForSeconds(time);
                BulletSpwanPos = this.gameObject.transform.GetChild(0).GetChild(3).GetChild(0).transform.position;
                tankView.GetController().FireBullet(BulletSpwanPos, this.gameObject.transform.rotation);
            }

        }

    }
}//namespace