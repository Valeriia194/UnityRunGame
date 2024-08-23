using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Project
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private EnemySpawnConfig _spawnConfig;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private LocalizationConfig localizationConfig;
        private void Start()
        {
            ProjectContext.Instance.Init(_spawnConfig, _playerStats, localizationConfig);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
