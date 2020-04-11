using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle_Tank.Bullets;
using Battle_Tank.Bullets;
using Battle_Tank.Bullets;

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


		public void fireBullet(Vector3 pos,Quaternion rot){

			TankShellModel shellModel = new TankShellModel(5f);
			TankShellController shell = new TankShellController (shellModel, shellView,parent,pos,rot);

		}//fireBullet


	



}//Class
}//Namespace
