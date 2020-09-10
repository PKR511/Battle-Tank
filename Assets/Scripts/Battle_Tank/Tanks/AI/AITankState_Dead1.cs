using Battle_Tank.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Battle_Tank.Tanks.AI
{

    public class AITankState_Dead1 : AIState
    {
        private Coroutine c;
        public override AIStateType GetStateType()
        {
            return AIStateType.Dead;
        }


        public override void OnEnterState()
        {
            base.OnEnterState();
            c = StartCoroutine(TankDead(1f));
        }

     
        public override void OnExitState()
        {
            base.OnExitState();
            StopCoroutine(c); 

        }

        public override AIStateType OnUpdate()
        {
           

            return AIStateType.Dead;
            
        }



        public void TankDeadEffect()
        {
            tankView.GetController().TankDestroyVFX(this.gameObject.transform.position, this.gameObject.transform.rotation);
            this.gameObject.SetActive(false);
             
        }
      
     


        public IEnumerator TankDead(float time)
        {
            yield return new WaitForSeconds(time);
            TankDeadEffect();

        }



    }//Class
}//namespace