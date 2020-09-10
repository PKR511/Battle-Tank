using Assets.Scripts.Battle_Tank.Helper.ScriptableObjects;
using Battle_Tank.Events;

using UnityEngine;
using System;

namespace Battle_Tank.Achievements
{
    public class AchievementService : GenericSingleton<AchievementService>
    {

        //private Variables
        [SerializeField]
        private AchievementScriptableObjectList achievementList;
        private AchievementModel[] model;
        private  int playerKill;

        protected override void Awake()
        {
            base.Awake();
            //Do your Thing
            playerKill = 0;
            if (achievementList.achievement.Length != 0)
            {
                model = new AchievementModel[achievementList.achievement.Length];
               
                SubscribeEvents();
                for(int i=0;i< achievementList.achievement.Length; i++)
                {
                    model[i] = new AchievementModel(achievementList.achievement[i].name, achievementList.achievement[i].type, achievementList.achievement[i].count);
                    
                }
            }
            Debug.Log("Event Service");
        }//Awake


        public void SubscribeEvents()
        {
            Debug.Log("SubscribeEvents() Is Called:");
            EventService.Instance.PlayerBulletFire += OnFireShell;
            EventService.Instance.PlayerDeath += OnPlayerDeath;
            EventService.Instance.PlayerKill += OnPlayerKill;

        }

      

        public void UnSubscribeEvents()
        {
            EventService.Instance.PlayerBulletFire -= OnFireShell;
            EventService.Instance.PlayerDeath -= OnPlayerDeath;
            EventService.Instance.PlayerKill -= OnPlayerKill;
            Debug.Log("UnSubscribeEvents() Is Called ");
        }

        private void OnFireShell(int count)
        {
            for (int i = 0; i < achievementList.achievement.Length; i++)
            {
                if (model[i].Type == AchievementType.BulletFire && model[i].Status==AchievementStatus.Locked && model[i].Count==count)
                {
                    model[i].Status = AchievementStatus.UnLocked;
                    Debug.Log("Achievement UnLocked:" + model[i].Name);
                }
            }
        }//OnFireShell

        private void OnPlayerDeath()
        {
            for (int i = 0; i < achievementList.achievement.Length; i++)
            {
                if (model[i].Type == AchievementType.Death)
                {
                    model[i].Status = AchievementStatus.UnLocked;
                    Debug.Log("Achievement UnLocked:" + model[i].Name);
                }
            }
        }

        public void OnPlayerKill()
        {
            playerKill++;
            for (int i = 0; i < achievementList.achievement.Length; i++)
            {
                if (model[i].Type == AchievementType.Kill && model[i].Count == playerKill)
                {
                    model[i].Status = AchievementStatus.UnLocked;
                    Debug.Log("Achievement UnLocked:" + model[i].Name);
                }
            }
        }

    }//class
}//namespace
