using Battle_Tank.Helper;
using Helper.Interface.IDamageable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Tanks
{
	/// <summary>
	/// Tank view.
	///	For Applying Any Visual Changes To Game Object 
	/// </summary>
	public class TankView : MonoBehaviour,IDamageable
	{

		//private Variable
		private Rigidbody myBody;
		private float rotationSpeed = 4f;
		private float rotY = 0f;
		private float moveHorizontal, moveVertical;
		private TankController tankController;
        [SerializeField]
        private float tankDestroyDuration = 1f;
        private Coroutine c;
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
		/// Update this instance.
		/// </summary>
		public void Update(){
			CheckInput ();
		}//Update

		/// <summary>
		/// Fixeds the update.
		/// </summary>
		public void FixedUpdate ()
		{
			
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
					Vector3 pos = this.gameObject.transform.GetChild (0).GetChild (3).GetChild (0).transform.position;

					if (tankController != null)
						tankController.RequestToFireBullet (pos, this.gameObject.transform.rotation);
					

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
				myBody.MovePosition (transform.position + transform.forward * (moveVertical *tankController.TankModel.Speed));

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
        /// <summary>
        /// Returns The Linked Controller
        /// </summary>
        /// <returns></returns>
        public TankController GetController()
        {
            return this.tankController;
        }//GetController

        public void TankDeadEffect()
        {
             c = StartCoroutine(TankDestroy(tankDestroyDuration));
            
         
        }//TankDeadEffect

        public IEnumerator TankDestroy(float time)
        {
            Time.timeScale = 0;

            yield return new WaitForSecondsRealtime(time);
            Time.timeScale = 1;
            tankController.TankDestroyVFX(this.gameObject.transform.position, this.gameObject.transform.rotation);
            this.gameObject.SetActive(false);

        }


        internal void DestroyAll()
        {
            StopAllCoroutines();
            //Destroy(this);

            
        }


        void IDamageable.TakeDamage(float damageAmount, string damageBy)
        {
            if (damageBy != MyTags.PLAYER_TAG)
                this.tankController.ApplyDamage(damageAmount);
        }

    }
    //Class
}
//namespace
