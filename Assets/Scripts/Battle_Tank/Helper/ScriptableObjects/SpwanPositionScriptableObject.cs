using System;
using UnityEngine;
using Battle_Tank.Tanks;

namespace Battle_Tank.Helper.ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpwanProperties", menuName = "ScriptableObjects/SpwanPositionProperty")]
    public class SpwanPositionProperty : ScriptableObject
    {
        public String Name;
        public Vector3 SpwanPos;
       

    }//class





    [CreateAssetMenu(fileName = "SpwanPropertiesList", menuName = "ScriptableObjects/SpwanPositionPropertyList")]
    public class SpwanPositionPropertyList : ScriptableObject
    {
        public SpwanPositionProperty[] pos;

    }//class


}//namespace