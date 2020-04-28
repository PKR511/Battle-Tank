using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// View For Explosion Effect
/// </summary>

namespace Battle_Tank.FX{
	public class FxExplosionView : MonoBehaviour {

	//private Variables
		private FxController fxController;
	

		/// <summary>
		/// Initialize the specified tankController.
		/// </summary>
		/// <param name="tankController">Tank controller.</param>
		public void Initialize (FxController fxController)
		{
			this.fxController = fxController;
		}
		//Initialize

		/// <summary>
		/// Explosions the effect.
		/// </summary>
		/// <param name="pos">Position.</param>
		/// <param name="rot">Rotation.</param>
		public void ExplosionEffect(Vector3 pos, Quaternion rot,GameObject parent){
			
			Instantiate (this.gameObject, pos,rot,parent.transform);

		}//ExplosionEffect



}//Classs
}//namespace