using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controller for VFX .
/// </summary>
namespace Battle_Tank.FX
{
	public class FxController
	{
		private FxExplosionView fxExplosionView;
		private FxExplosionModel fxExplosionModel;


		public FxController(FxExplosionView fxExplosionView){
			this.fxExplosionView = fxExplosionView;
			this.fxExplosionView.Initialize (fxController: this);
			Debug.Log ("Fx Controller");
		}//FxController


		/// <summary>
		/// FX Service For Fire Bullet
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void ExplosionFX (Vector3 pos, Quaternion rot,GameObject parent)
		{
			this.fxExplosionView.ExplosionEffect (pos, rot,parent);

		}//fireBulletFx



	}
//Class
}
//nameScpace