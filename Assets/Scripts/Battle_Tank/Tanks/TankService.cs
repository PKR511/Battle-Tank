using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle_Tank.Tanks;
using Battle_Tank.Tanks;
using Battle_Tank.Tanks;
using Battle_Tank.Bullets;

namespace Battle_Tank.Tanks
{
	public class TankService : GenericSingleton<TankService>
	{
		//private Variables
		[SerializeField]
		private TankView[] tankView;
		[SerializeField]
		private GameObject parent;


		private float moveHorizontal, moveVertical;

		// Use this for initialization
		protected override	void Awake ()
		{
			base.Awake ();
			//Do your Thing

			Debug.Log ("Tank Service");
		}//Awake
	

		protected void Update ()
		{
			CheckInput ();
		}//update


		private void CheckInput ()
		{
			//If Block to spwan tank Start
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				TankModel tankModl = new TankModel (5f, 100f, 0.1f);
				Vector3 pos = new Vector3 (1, 1, 0);
				TankController tank = new TankController (tankModl, tankView [0], parent, pos);

				Debug.Log ("Key 1 Pressed" + tankView [0].gameObject.name);
			}//if
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				TankModel tankModl = new TankModel (5f, 100f, 0.2f);
				Vector3 pos = new Vector3 (6, 1, 0);
				TankController tank = new TankController (tankModl, tankView [1], parent, pos);

				Debug.Log ("Key 2 Pressed" + tankView [1].gameObject.name);
			}//if
			if (Input.GetKeyDown (KeyCode.Alpha3)) {
				TankModel tankModl = new TankModel (5f, 100f, 0.5f);
				Vector3 pos = new Vector3 (-6, 1, 0);

				TankController tank = new TankController (tankModl, tankView [2], parent, pos);

				Debug.Log ("Key 3 Pressed" + tankView [2].gameObject.name);
			}//if
			//If Block to spwan tank Ends


		}//CheckInput

		public void FireBullet(){

		}

	}//Class
}//namespace
