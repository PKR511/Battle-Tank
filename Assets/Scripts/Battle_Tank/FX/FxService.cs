using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Service Class For  VFX .
/// </summary>
namespace Battle_Tank.FX
{
	public class FxService : GenericSingleton<FxService>
	{
		//private Variables
		[SerializeField]
		private FxExplosionView shellExplosionView;
        [SerializeField]
        private FxExplosionView tankExplosionView;
        [SerializeField]
		private GameObject parent;
		// Use this for initialization
		protected override	void Awake ()
		{
			base.Awake ();
			//Do your Thing

			Debug.Log ("Tank Service");
		}
		//Awake

		/// <summary>
		/// FX Service For Fire Bullet
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void fireBulletFX (Vector3 pos, Quaternion rot)
		{
           
			FxController controller = new FxController (shellExplosionView);
			controller.ExplosionFX (pos, rot,parent);
		

		}//fireBulletFX

		/// <summary>
		/// FX Service For Fire Bullet
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void ShellCollisionEffect (Vector3 pos, Quaternion rot)
		{
			FxController controller = new FxController (shellExplosionView);
			controller.ExplosionFX (pos, rot,parent);


		}//ShellCollisionEffect

        public void TankExplosionEffect(Vector3 pos, Quaternion rot)
        {
            FxController controller = new FxController(tankExplosionView);
            controller.ExplosionFX(pos, rot, parent);


        }//ShellCollisionEffect



    }
    //Class


}
//nameSpace