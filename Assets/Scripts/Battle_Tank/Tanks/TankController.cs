using System;
using Battle_Tank.Events;

using UnityEngine;
using Battle_Tank.Achievements;

namespace Battle_Tank.Tanks{

public class TankController  {

		//private variables
		private TankModel tankModel;
		private TankView tankView;
        private int fireShellCount;
       
        //Property
        public  TankModel TankModel {get{return tankModel;}}
		public  TankView TankView {get{return tankView;}}
		//Default Constructor
		public TankController(){
			
		}//TankController

		//Param Constructor
		public TankController(TankModel tankModel,TankView tankView,GameObject parent,Vector3 pos){
			this.tankModel = tankModel;

			this.tankView = GameObject.Instantiate<TankView>(tankView);
			this.tankView.transform.SetParent (parent.transform);
			this.tankView.transform.position = pos;
			this.tankView.Initialize(tankController:this);
            fireShellCount = 0;
            SubscribeEvents();
			Debug.Log ("Tank instantiated");

		}//TankController


		public void RequestToFireBullet(Vector3 pos,Quaternion rot){
            fireShellCount++;
			TankService.Instance.FireBullet (pos,rot);
            EventService.Instance.InvokePlayerBulletFireEvent(fireShellCount);


        }//requestToFireBullets




        public void ApplyDamage(float damageAmount)
        {
            this.TankModel.Health -= damageAmount;
            if (this.TankModel.Health <= 0)
            {

                tankView.TankDeadEffect();
                EventService.Instance.InvokePlayerDeathEvent();
                Debug.Log(":Killed");
                //this.Destroy();
                TankService.Instance.PlayerDead = true;
               
            }
            
            // Debug.Log("Tank Health:" + this.TankModel.Health);
        }
        public void Destroy()
        {
            this.tankModel = null;
            this.TankView.DestroyAll();
            this.tankView = null;
            UnSubscribeEvents();
            AchievementService.Instance.UnSubscribeEvents();
        }//Destroy

        public void TankDestroyVFX(Vector3 pos, Quaternion rot)
        {
            TankService.Instance.TankDestroyVFX(pos, rot);
        }

        public void SubscribeEvents()
        {
           EventService.Instance.PlayerBulletFire += OnFireShell;

            Debug.Log("SubscribeEvents() Is Called:");
        }
        public void UnSubscribeEvents()
        {
            EventService.Instance.PlayerBulletFire -= OnFireShell;
            Debug.Log("UnSubscribeEvents() Is Called ");
        }
        private void OnFireShell(int count)
        {
            
            Debug.Log("OnFireShell Event is called "+count);
        }
    }//Class
}//namespace
