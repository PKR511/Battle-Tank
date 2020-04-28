using Battle_Tank.Helper.ScriptableObjects;
namespace Battle_Tank.Tanks
{
	public class EnemyTankModel
	{

		//private Variables
		private float speed, health, damage;
		private bool active, spwaned;
		//Property
		public  float Speed { get { return speed; } set { speed = value; } }

		public  float Health { get { return health; } set { health = value; } }

		public  float Damage { get { return damage; } set { damage = value; } }

		public  bool Active { get { return active; } set { active = value; } }

		public  bool Spwaned { get { return spwaned; } set { spwaned = value; } }

		//Default Constructor
		public EnemyTankModel ()
		{
			
		}//TankModel

		//Para Constructor
		public EnemyTankModel(float speed, float health, float damage)
		{

			this.speed = speed;
			this.health = health;
			this.damage = damage;
			this.active = false;
			this.spwaned = false;
		}//TankModel

        public EnemyTankModel(EnemyTankScriptableObject tank)
        {
            this.speed = tank.Speed;
            this.health = tank.Health;
            this.damage = tank.Damage;
            this.active = false;
            this.spwaned = false;
        }

	}
//Class
}//namespace