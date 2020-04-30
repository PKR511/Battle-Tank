using UnityEngine;
using Battle_Tank.FX;
using Battle_Tank.Tanks.Enemy;
using Battle_Tank.Helper;
using Battle_Tank.Tanks;

namespace Battle_Tank.Bullets{
	public class TankShellService: GenericSingleton<TankShellService> {
		
		//private Variables
		[SerializeField]
		private TankShellView  shellView;
		[SerializeField]
		private GameObject parent;


		// Use this for initialization
		protected override	void Awake () {
			base.Awake ();
			//Do your Thing
			Debug.Log("Shell Service");
		}//Awake

		/// <summary>
		/// Tank Shell Service Method To Fire Bullet
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void fireBullet(Vector3 pos,Quaternion rot,string firedBy){

			TankShellModel shellModel = new TankShellModel(5f,10f,firedBy);
            
			TankShellController shell = new TankShellController (shellModel, shellView,parent,pos,rot);

		}//fireBullet


		/// <summary>
		/// Shells the collision effect.
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rot.</param>
		public void ShellCollisionEffect(Vector3 pos, Quaternion rot){
			FxService.Instance.ShellCollisionEffect (pos, rot);
			Debug.Log (this + ":ShellCollisionEffect");
		}//ShellCollisionEffect

        public void DealDamage(float amount, GameObject obj, string tag)
        {
            float tankHealth = GetTankHealth(obj, tag);

            SetTankHealth(tankHealth-amount, obj, tag);

           
           

        }    

        public float GetTankHealth(GameObject obj, string tag)
        {
            float tankHealth = 0f;
            if (tag == MyTags.ENEMY_TAG)
            {
                 tankHealth = EnemyTankService.Instance.GetTankHealth(obj.GetComponent<EnemyTankView>());

            }
            if (tag == MyTags.PLAYER_TAG)
            {
                tankHealth = TankService.Instance.GetTankHealth(obj.GetComponent<TankView>());

            }
            return tankHealth;
           
        }


        public void SetTankHealth(float amount, GameObject obj, string tag)
        {
           
            if (tag == MyTags.ENEMY_TAG)
            {
                EnemyTankService.Instance.SetHealth(obj.GetComponent<EnemyTankView>(), amount);

            }
            if (tag == MyTags.PLAYER_TAG)
            {
                TankService.Instance.SetHealth(obj.GetComponent<TankView>(), amount);

            }


        }
    }//Class
}//Namespace
