using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Events
{
    public class EventService : GenericSingleton<EventService>
    {

        //public events
        public event Action<int> PlayerBulletFire;
        public event Action PlayerDeath;
        public event Action PlayerKill;

        protected override void Awake()
        {
            base.Awake();
            //Do your Thing

            Debug.Log("Event Service");
        }//Awake


        public void InvokePlayerBulletFireEvent(int count)
        {
            PlayerBulletFire?.Invoke(count);
        }
        public void InvokePlayerDeathEvent() {
            PlayerDeath?.Invoke();
        }

        public void InvokePlayerKillEvent()
        {
            PlayerKill?.Invoke();
        }
    }//class
}//namespace
