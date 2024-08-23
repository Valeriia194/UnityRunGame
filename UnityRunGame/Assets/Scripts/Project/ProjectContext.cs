using Assets.Scripts.Audio;
using Assets.Scripts.Project;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Project
{
    public class ProjectContext
    {
        private static ProjectContext instance;

        public static ProjectContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProjectContext();

                return instance;
            }
        }

        public IDataService DataService { get; private set; }
        public IAudioService AudioService { get; private set; }
        public ILocalizationService LocalizationService { get; private set; }
        //public ISaveLoadService SaveLoadService { get; private set; }

        private ProjectContext()
        {

        }



        public void Init(EnemySpawnConfig enemySpawnConfig, PlayerStats playerStats, LocalizationConfig localizationConfig)
        {
            DataService = new DataService(enemySpawnConfig, playerStats, localizationConfig);
            AudioService = new AudioService();
            LocalizationService = new LocalizationService(DataService/*, SaveLoadService*/);
            //SaveLoadService = new SaveLoadService();
        }
    }

}