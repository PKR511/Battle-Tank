using UnityEngine;
using Battle_Tank.Bullets;
using Battle_Tank.FX;
using Battle_Tank.Helper.ScriptableObjects;

namespace Battle_Tank.Tanks
{
	public class TankService : GenericSingleton<TankService>
	{
		//private Variables
		
		[SerializeField]
		private GameObject parent;
        [SerializeField]
        private TankScriptableObjectList tankList;
        [SerializeField]
        private Helper.Camera.CameraFollow cameraFollow;
        private float moveHorizontal, moveVertical;
        private bool playerSpwaned;

		// Use this for initialization
		protected override	void Awake ()
		{
			base.Awake ();
            //Do your Thing
            playerSpwaned = false;
			Debug.Log ("Tank Service");
		}//Awake
	

		protected void Update ()
		{
            if (!playerSpwaned)
            {
                CheckInput();
            }
		}//update

		/// <summary>
		/// Tanks Service Method To CHeck Input To Spwan Tank
		/// </summary>
		private void CheckInput ()
		{
			//If Block to spwan tank Start
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
                int index = Random.Range(0, tankList.tank.Length);
                TankScriptableObject tankObject = tankList.tank[0];
                TankModel tankModel = new TankModel(tankObject);
				Vector3 pos = new Vector3 (1, 0, 0);
				TankController tank = new TankController (tankModel, tankList.tank[0].tankView, parent, pos);
                cameraFollow.enabled = true;
                playerSpwaned = true;

                Debug.Log ("Key 1 Pressed" + tankList.tank[0].Name);
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
			TankShellService.Instance.fireBullet (pos,rot);

		}//FireBullet

	}//Class
}//namespace
