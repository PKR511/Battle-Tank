using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Bullets
{
	[RequireComponent(typeof(Rigidbody))]
	public class TankShellView : MonoBehaviour
	{

		//Private Variables
		private TankShellController shellController;
		private Rigidbody myBody;


		/// <summary>
		/// Awake this instance.
		/// </summary>
		void Awake ()
		{
			myBody = gameObject.GetComponent<Rigidbody> ();
			Debug.Log ("Tank Shell");
		}
		//Awake
	
		/// <summary>
		/// Initialize the specified shellController.
		/// </summary>
		/// <param name="shellController">Shell controller.</param>
		public void Initialize (TankShellController shellController)
		{
			this.shellController = shellController;
		}
		//Initialize


		/// <summary>
		/// Method Used to Move  Object in forward direction.
		/// </summary>
		public void Move ()
		{			
			
			this.myBody.AddForce (this.myBody.transform.forward * 20f, ForceMode.VelocityChange);

			Debug.Log ("Move is Called"+myBody.transform.forward*100f);

		}
		//Move

	}
	//Class
}
//Namespace
