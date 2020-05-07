using Battle_Tank.Tanks;
using Battle_Tank.Tanks;
using UnityEngine;

namespace Battle_Tank.Tanks{

public class TankController  {

		//private variables
		private TankModel tankModel;
		private TankView tankView;


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
			Debug.Log ("Tank instantiated");

		}//TankController


		public void RequestToFireBullet(Vector3 pos,Quaternion rot){

			TankService.Instance.FireBullet (pos,rot);

		}//requestToFireBullets




        public void ApplyDamage(float damageAmount)
        {
            this.TankModel.Health -= damageAmount;
            if (this.TankModel.Health <= 0)
            {

                tankView.TankDeadEffect();
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


        }//Destroy

        public void TankDestroyVFX(Vector3 pos, Quaternion rot)
        {
            TankService.Instance.TankDestroyVFX(pos, rot);
        }

    }//Class
}//namespace
