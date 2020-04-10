using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Tanks
{
	/// <summary>
	/// Tank view.
	///	For Applying Any Visual Changes To Game Object 
	/// </summary>
	public class TankView : MonoBehaviour
	{

		//private Variable
		private Rigidbody myBody;
		private float rotationSpeed = 4f;
		private float rotY = 0f;
		private float moveHorizontal, moveVertical;
		private TankController tankController;

		//Method Defination

		/// <summary>
		/// Awake is called first when game object is invoked and is been used for initialization.
		/// </summary>
		void Awake ()
		{
			rotY = transform.localRotation.eulerAngles.y;
			moveVertical = 0;
			moveHorizontal = 0;
			myBody = gameObject.GetComponent<Rigidbody> ();
			Debug.Log ("Tank View");
		}
		//Awake


		/// <summary>
		/// Fixeds the update.
		/// </summary>
		public void FixedUpdate ()
		{
			CheckInput ();
			Move ();
			Rotate ();
		
		}
		//FixedUpdate


	
		/// <summary>
		/// Checks the keyboard input.
		/// </summary>
		private void CheckInput ()
		{
			//If Block For tamk Move Start

			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				moveHorizontal = -1;
			} 

			if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
				moveHorizontal = 0;
			} 

			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
				moveHorizontal = 1;
			}

			if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
				moveHorizontal = 0;
			}

			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
				moveVertical = 1;
			}

			if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
				moveVertical = 0;
			}

			//If Block For tamk Move Start

			//If Block For Tank Bullet Fire Start
			if (Input.GetKeyDown (KeyCode.F)) {
				{
					tankController.RequestToFireBullet (TankView);


				}
				Debug.Log ("Key F Pressed ");
			}
			//If Block For Tank Bullet Fire Ends


		}
		//CheckInput

		/// <summary>
		/// Method Used to Move  Object in forward direction.
		/// </summary>
		public void Move ()
		{			
			if (moveVertical != 0f) {
				myBody.MovePosition (transform.position + transform.forward * (moveVertical *0.1f));

			}

		}
		//Move

		/// <summary>
		/// Rotate this instance on Y axix.
		/// </summary>
		public void Rotate ()
		{
			if (moveHorizontal != 0) {
				rotY += moveHorizontal * rotationSpeed;
				myBody.rotation = Quaternion.Euler (0f, rotY, 0f);
			}
		}
		//Rotate

		/// <summary>
		/// Initialize the specified tankController.
		/// </summary>
		/// <param name="tankController">Tank controller.</param>
		public void Initialize (TankController tankController)
		{
			this.tankController = tankController;
		}
		//Initialize
			

	}
	//Class
}
//namespace
