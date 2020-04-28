using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Tanks.Enemy
{
	/// <summary>
	/// Tank view.
	///	For Applying Any Visual Changes To Game Object 
	/// </summary>
	public class EnemyTankView : MonoBehaviour
	{

		//private Variable
		private Rigidbody myBody;
		private float rotationSpeed = 4f;
		private float rotY = 0f;
		private float moveHorizontal, moveVertical;
		private EnemyTankController tankController;

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

		
		public void TankDeadEffect()
        {
            tankController.TankDestroyVFX(this.gameObject.transform.position, this.gameObject.transform.rotation);
            this.gameObject.SetActive(false);
            //Coroutine c = StartCoroutine(TankDead(1f));
        }
		public void DestroyAll ()
		{


           // StopAllCoroutines();


            
            Debug.Log(gameObject + ":Killed");
               
          
		}
		//FixedUpdate


	    public IEnumerator TankDead(float time)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);

        }
		

		/// <summary>
		/// Initialize the specified tankController.
		/// </summary>
		/// <param name="tankController">Tank controller.</param>
		public void Initialize (EnemyTankController tankController)
		{
			this.tankController = tankController;
		}
		//Initialize
		public EnemyTankController GetController()
        {
            return this.tankController;
        }	

	}
	//Class
}
//namespace
