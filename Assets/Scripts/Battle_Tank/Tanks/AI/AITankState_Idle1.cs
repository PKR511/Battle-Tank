using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Tanks.AI
{
    public class AITankState_Idle1 : AIState
    {

        // Inspector Assigned 
        [SerializeField]
        Vector2 _idleTimeRange = new Vector2(10.0f, 60.0f);

        float _idleTime = 0.0f;
        float _timer = 0.0f;

        public override AIStateType GetStateType()
        {
            return AIStateType.Idle;
        }


        public override void OnEnterState()
        {
            base.OnEnterState();
            _idleTime = UnityEngine.Random.Range(_idleTimeRange.x, _idleTimeRange.y);
            _timer = 0.0f;
        }
        public override AIStateType OnUpdate()
        {

           if (tankView.targetType == AITargetType.Waypoint)
            {
                return AIStateType.Patrol;
            }
            if (tankView.targetType == AITargetType.Player)
            {
                              
                return AIStateType.Pursuit;
            }
            if (tankView.GetController().TankModel.Health <= 0)
            {
                return AIStateType.Dead;
            }

            // Update the idle timer
            _timer += Time.deltaTime;

            // Patrol if idle time has been exceeded
            if (_timer > _idleTime)
            {
                tankView.targetType = AITargetType.Waypoint;
                return AIStateType.Patrol;
                
            }

            return AIStateType.Idle;
        }


        public override void OnExitState()
        {
            base.OnExitState();
            _timer = 0;
        }


      

    }//class
}//namespace
