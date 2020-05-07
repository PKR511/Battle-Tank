using Battle_Tank.Tanks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Helper.Camera
{
    public class CameraFollow : MonoBehaviour
    {


        private Transform target;
        [Range(0.0f,1.0f)]
        public float smoothFollow = 0.01f;
       

        public void OnEnable()
        {
            GameObject obj = GameObject.FindGameObjectWithTag(MyTags.PLAYER_TAG).transform.Find("CameraPosition").gameObject;
            target = obj.transform;
         

        }
        public void LateUpdate()
        {

            transform.position = Vector3.Slerp(transform.position, target.transform.position ,smoothFollow);
            
            transform.rotation = target.transform.rotation;
        }
    }//class
}//namespace
