using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Battle_Tank.Helper.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WayPoints", menuName = "ScriptableObjects/WayPointsProperty")]
    public class WayPointScriptableObject : ScriptableObject
    {
        public string name;
        public Transform points;
    }

}