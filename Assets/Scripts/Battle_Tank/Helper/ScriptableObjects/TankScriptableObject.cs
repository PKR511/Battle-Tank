using System;
using UnityEngine;
using Battle_Tank.Tanks;

namespace Battle_Tank.Helper.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Properties", menuName = "ScriptableObjects/TankProperty")]
    public class TankScriptableObject : ScriptableObject
    {
        public String Name;
        public float Speed;
        public float Health;
        public float Damage;
        public TankView tankView;

    }//class





    [CreateAssetMenu(fileName = "PropertiesList", menuName = "ScriptableObjects/TankPropertyList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tank;

    }//class


}//namespace