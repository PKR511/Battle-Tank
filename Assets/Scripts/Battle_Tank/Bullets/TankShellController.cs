using Battle_Tank.Bullets;
using Battle_Tank.Bullets;
using UnityEngine;

namespace Battle_Tank.Bullets{
public class TankShellController  {

	
		//private variables
		private TankShellModel tankShellModel;
		private TankShellView tankShellView;

		//Property
		public  TankShellModel TankShellModel {get{return tankShellModel;}}
		public  TankShellView TankShellView {get{return tankShellView;}}
		//Default Constructor
		public TankShellController(TankShellModel shellModel, TankShellView shellView,GameObject parent,Vector3 pos,Quaternion rot){
			this.tankShellModel = shellModel;
			this.tankShellView = GameObject.Instantiate<TankShellView>(shellView);
			this.tankShellView.transform.SetParent (parent.transform);
			this.tankShellView.transform.position = pos;
			this.tankShellView.transform.rotation = rot;
			this.tankShellView.Initialize (shellController: this);
			this.tankShellView.Move ();
			Debug.Log ("Tank instantiated");

		}//TankController






}//Class
}//namespace
