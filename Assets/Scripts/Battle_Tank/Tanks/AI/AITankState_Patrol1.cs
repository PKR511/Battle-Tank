using UnityEngine;

using UnityEngine.AI;

namespace Battle_Tank.Tanks.AI
{
    public class AITankState_Patrol1 : AIState
    {
        private GameObject[] wayPoints;
        private NavMeshAgent navAgent;
        private int walk_Index;
        public override AIStateType GetStateType()
        {
            return AIStateType.Patrol;
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            navAgent = GetComponent<NavMeshAgent>();
            wayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
        }
        public override void OnExitState()
        {
            base.OnExitState();
            navAgent.Stop();

        }

        public override AIStateType OnUpdate()
        {

            if (tankView.targetType == AITargetType.Player)
            {
                
                return AIStateType.Pursuit;
            }
            if (tankView.GetController().TankModel.Health <= 0)
            {
                return AIStateType.Dead;
            }
            SetNextDestination(ChooseWalkPoint());

            return AIStateType.Patrol;
        }

        public int ChooseWalkPoint()
        {
            if (navAgent.remainingDistance <= 0.1f)
            {
                // navAgent.SetDestination(walk_Points[walk_Index].position);

                //if (walk_Index == wayPoints.Length - 1)
                //{
                //    walk_Index = 0;
                //}
                //else {
                //    walk_Index++;
                //}
                walk_Index = Random.Range(0, wayPoints.Length);
            }
            return walk_Index;
        }

        public void SetNextDestination(int index)
        {
            navAgent.SetDestination(wayPoints[index].transform.position);
        }

    }
}//namespace