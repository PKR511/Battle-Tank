namespace Battle_Tank.Bullets{
public class TankShellModel {

		//private Variables
		private float speed;
		private bool active, spawned;
		//Property
		public  float Speed {get{return speed;}set{speed=value;}}
		public  bool Active {get{return active;}set{active=value;}}
		public  bool Spawned {get{return spawned;}set{spawned=value;}}


		//Default Constructor
		public TankShellModel(float speed){

			this.speed = speed;
			this.active = true;
			this.spawned = true;

		}//TankShellModel


	
}//Class
}//Namespace
