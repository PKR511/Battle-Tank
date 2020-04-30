using UnityEngine;

namespace Battle_Tank.Tanks.Enemy{

public class EnemyTankController  {

		//private variables
		private EnemyTankModel tankModel;
		private EnemyTankView tankView;


		//Property
		public  EnemyTankModel TankModel {get{return tankModel;}}
		public  EnemyTankView TankView {get{return tankView;}}
		//Default Constructor
		public EnemyTankController(){
			
		}//TankController

		//Param Constructor
		public EnemyTankController(EnemyTankModel tankModel,EnemyTankView tankView,GameObject parent,Vector3 pos){
			this.tankModel = tankModel;

			this.tankView = GameObject.Instantiate<EnemyTankView>(tankView);
			this.tankView.transform.SetParent (parent.transform);
			this.tankView.transform.position = pos;
			this.tankView.Initialize(tankController:this);
			Debug.Log ("Tank instantiated");

		}//TankController


		public void SetHealth(float health)
        {
            this.TankModel.Health = health;
            if (this.TankModel.Health == 0)
            {

                tankView.TankDeadEffect();
                Debug.Log( ":Killed");
               this. Destroy();
            }
           // Debug.Log("Tank Health:" + this.TankModel.Health);
        }

        public void Destroy()
        {
            this. tankModel = null;
            this.TankView.DestroyAll();
            this.tankView = null;


        }//Destroy

        public void FireBullet(Vector3 pos, Quaternion rot)
        {

            EnemyTankService.Instance.FireBullet(pos, rot);

        }//requestToFireBullets

        public void TankDestroyVFX(Vector3 pos, Quaternion rot)
        {
            EnemyTankService.Instance.TankDestroyVFX(pos,rot);
        }
    }//Class
}//namespace
