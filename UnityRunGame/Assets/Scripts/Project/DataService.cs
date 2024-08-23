using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public interface IDataService { 
        EnemyCount[] EnemyCounts  { get; }
        PlayerStats PlayerStats { get; }
        LocalizationKey[] Localization { get; }

}
    public class DataService : IDataService
    {
        public EnemyCount[] EnemyCounts { get; }
        public PlayerStats PlayerStats { get; }
        public LocalizationKey[] Localization { get; }
    public DataService(EnemySpawnConfig enemySpawnConfig, PlayerStats playerStats, LocalizationConfig localizationConfig) 
        {
            EnemyCounts = enemySpawnConfig.EnemiesCount;
            PlayerStats = playerStats;
            Localization = localizationConfig.localizationKeys;

    }

    }

