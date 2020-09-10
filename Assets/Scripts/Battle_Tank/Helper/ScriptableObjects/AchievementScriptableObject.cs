
using Battle_Tank.Achievements;
using UnityEngine;

namespace Assets.Scripts.Battle_Tank.Helper.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Achievement", menuName = "ScriptableObjects/AchievementProperty")]
   public class AchievementScriptableObject: ScriptableObject
    {
        public string name;
        public AchievementType type;
        public AchievementStatus status;
        public int count;


    }


    [CreateAssetMenu(fileName = "AchievementList", menuName = "ScriptableObjects/AchievementPropertyList")]
    public class AchievementScriptableObjectList : ScriptableObject
    {
        public AchievementScriptableObject[] achievement;

    }//class

}
