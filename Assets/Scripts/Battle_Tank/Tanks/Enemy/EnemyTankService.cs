
using UnityEngine;
using Battle_Tank.Bullets;
using Battle_Tank.FX;
using Battle_Tank.Helper.ScriptableObjects;
using Battle_Tank.Helper;

namespace Battle_Tank.Tanks.Enemy
{
	public class EnemyTankService : GenericSingleton<EnemyTankService>
	{
		//private Variables
		
		[SerializeField]
		private GameObject parent;
        [SerializeField]
        private EnemyTankScriptableObjectList tankList;
        [SerializeField]
        private SpwanPositionPropertyList posList;


        // Use this for initialization
        protected override	void Awake ()
		{
			base.Awake ();
			//Do your Thing

			Debug.Log ("Enemy Tank Service");
		}//Awake
	

		protected void Update ()
		{
			CheckInput ();
		}//update

		/// <summary>
		/// Tanks Service Method To CHeck Input To Spwan Tank
		/// </summary>
		private void CheckInput ()
		{
			//If Block to spwan tank Start
			if (Input.GetKeyDown (KeyCode.Alpha0)) {
                int index = Random.Range(0, tankList.tank.Length);
                int index2 = Random.Range(0, posList.pos.Length);
                EnemyTankScriptableObject tankObject = tankList.tank[index];
                EnemyTankModel tankModel = new EnemyTankModel(tankObject);
               
                EnemyTankController tank = new EnemyTankController(tankModel,tankList.tank[index].tankView , parent, posList.pos[index2].SpwanPos);

                Debug.Log("Key 1 Pressed" + tankList.tank[index].Name);

            }//if
			
			//If Block to spwan tank Ends


		}//CheckInput

		/// <summary>
		/// Tank Service Method To Fire Bullet
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void FireBullet(Vector3 pos,Quaternion rot){
			//Calling Fx Service To Instantiate Fire Shell VFX
			FxService.Instance.fireBulletFX(pos,rot);
			//Calling TankShell Service To Instantiate Shell
			TankShellService.Instance.fireBullet (pos,rot,MyTags.ENEMY_TAG);

		}//FireBullet


        public float GetTankHealth(EnemyTankView obj)
        {
            return obj.GetController().TankModel.Health;
        }

        public void SetHealth(EnemyTankView obj,float health)
        {
            Debug.Log("Health==" + health);
            obj.GetController().SetHealth(health);
            
        }


        public void TankDestroyVFX(Vector3 pos, Quaternion rot)
        {
            FxService.Instance.TankExplosionEffect(pos, rot);
        }




    }//Class
}//namespace
