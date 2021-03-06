﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Battle_Tank.Helper;
using Battle_Tank.Tanks.Enemy;
using Helper.Interface.IDamageable;

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
		/// <summary>
		/// Raises the collision enter event.
		/// Used To Detect Shell Collision to Other Object.
		/// </summary>
		/// <param name="traget">Traget.</param>
		public void OnTriggerEnter(Collider target){


            IDamageable damageable = target.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                if (!target.isTrigger)
                {
                    shellController.ShellCollisionEffect(this.gameObject.transform.position, this.gameObject.transform.rotation);
                    damageable.TakeDamage(shellController.TankShellModel.Damage, shellController.TankShellModel.FiredBy);
                    Destroy(this.gameObject);

                }
               
            }
           
           

        }//OnCollisionEnter

    }
	//Class
}
//Namespace
