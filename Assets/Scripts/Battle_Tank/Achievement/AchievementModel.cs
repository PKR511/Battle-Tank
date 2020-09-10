using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle_Tank.Achievements
{

     public enum AchievementType { None,BulletFire,Kill,Death}
     public  enum AchievementStatus { None, Locked,UnLocked }
    public class AchievementModel
    {
        private string name;
        private AchievementType type;
        private AchievementStatus status;
        private int count;

        public string Name
        {
            get
            {
                return name;
            }

          
        }

        public AchievementType Type
        {
            get
            {
                return type;
            }

          
        }

        public AchievementStatus Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

          
        }

        public AchievementModel(string name, AchievementType type, int count)
        {
            this.name = name;
            this.type = type;
            this.status = AchievementStatus.Locked;
            this.count = count;
        }

        public AchievementModel()
        {
        }
    }//class
}//namespace
