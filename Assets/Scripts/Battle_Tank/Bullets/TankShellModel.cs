namespace Battle_Tank.Bullets{
public class TankShellModel {

		//private Variables
		private float speed,damage;
		private bool active, spawned;
		//Property
		public  float Speed {get{return speed;}}
		public  bool Active {get{return active;}set{active=value;}}
		public  bool Spawned {get{return spawned;}set{spawned=value;}}

        public float Damage
        {
            get
            {
                return damage;
            }

          
        }


        //Default Constructor
        public TankShellModel(float speed,float damage){

			this.speed = speed;
            this.damage = damage;
			this.active = true;
			this.spawned = true;

		}//TankShellModel


	
}//Class
}//Namespace
