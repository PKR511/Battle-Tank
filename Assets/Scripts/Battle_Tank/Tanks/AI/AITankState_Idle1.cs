using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Tanks.AI
{
    public class AITankState_Idle1 : AIState
    {
        public override AIStateType GetStateType()
        {
            return AIStateType.Idle;
        }

        public override AIStateType OnUpdate()
        {
            Debug.Log("Idle State");
            return AIStateType.Idle;
        }


    }//class
}//namespace
