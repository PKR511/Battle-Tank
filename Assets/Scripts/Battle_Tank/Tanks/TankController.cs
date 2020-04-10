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
			this.tankModel = TankModel;

			this.tankView = GameObject.Instantiate<TankView>(tankView);
			this.tankView.transform.SetParent (parent.transform);
			this.tankView.transform.position = pos;
			tankView.Initialize (this);
			Debug.Log ("Tank instantiated");

		}//TankController


		public void requestToFireBullets(TankView tankView){

			TankService.Instance.FireBullet (tankView);

		}//requestToFireBullets


}//Class
}//namespace
