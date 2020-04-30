using Battle_Tank.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        private Coroutine coroutine;
        [SerializeField]
        private float attackDuration = 0.0f;
        private EnemyTankController tankController;
        private Vector3 BulletSpwanPos;

        //Method Defination

        /// <summary>
        /// Awake is called first when game object is invoked and is been used for initialization.
        /// </summary>
        void Awake()
        {
           

            myBody = gameObject.GetComponent<Rigidbody>();
            Debug.Log("Tank View");
        }
        //Awake



        /// <summary>
        /// Initialize the specified tankController.
        /// </summary>
        /// <param name="tankController">Tank controller.</param>
        public void Initialize(EnemyTankController tankController)
        {
            this.tankController = tankController;
        }
        //Initialize

        /// <summary>
        /// Returns The Linked Controller
        /// </summary>
        /// <returns></returns>
        public EnemyTankController GetController()
        {
            return this.tankController;
        }//GetController

        /// <summary>
        /// Invoked OnTrigger Event to Detect Collision
        /// </summary>
        /// <param name="target"></param>
        public void OnTriggerEnter(Collider target)
        {
            if (target.tag == MyTags.PLAYER_TAG)
            {
                RotateEnemyToward(target.gameObject.transform.position);
                coroutine = StartCoroutine(Attack(attackDuration));
            }

            }//OnTriggerEnter



        public void OnTriggerExit(Collider target)
        {
            if (target.tag == MyTags.PLAYER_TAG)
            {
                RotateEnemyToward(target.gameObject.transform.position);
                StopCoroutine(coroutine);
            }

        }//OnTriggerEnter


        private void RotateEnemyToward(Vector3 pos)
        {
            Vector3 lookVector = pos - this.transform.position;
            lookVector.y = transform.position.y;
            Quaternion rot = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
        }//RotateEnemyToward


       public IEnumerator Attack(float time)
        {
            while (true)
            {
                BulletSpwanPos = this.gameObject.transform.GetChild(0).GetChild(3).GetChild(0).transform.position;
                this.tankController.FireBullet(BulletSpwanPos, this.gameObject.transform.rotation);
                yield return new WaitForSeconds(time);
            }
            
        }


        public void TankDeadEffect()
        {
            tankController.TankDestroyVFX(this.gameObject.transform.position, this.gameObject.transform.rotation);
            this.gameObject.SetActive(false);
            //Coroutine c = StartCoroutine(TankDead(1f));
        }
        public void DestroyAll()
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

    } //Class
}
//namespace
