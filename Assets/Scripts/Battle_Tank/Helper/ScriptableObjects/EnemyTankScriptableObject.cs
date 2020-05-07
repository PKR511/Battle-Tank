using System;
using UnityEngine;

using Battle_Tank.Tanks.Enemy;

namespace Battle_Tank.Helper.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Properties", menuName = "ScriptableObjects/EnemyTankProperty")]
    public class EnemyTankScriptableObject : ScriptableObject
    {
        public String Name;
        public float Speed;
        public float Health;
        public float Damage;
        public EnemyTankView tankView;

    }//class





    [CreateAssetMenu(fileName = "PropertiesList", menuName = "ScriptableObjects/EnemyTankPropertyList")]
    public class EnemyTankScriptableObjectList : ScriptableObject
    {
        public EnemyTankScriptableObject[] tank;

    }//class


}//namespace