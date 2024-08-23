//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using Random = UnityEngine.Random;

//public class EnemySpawner : MonoBehaviour
//{
//    [SerializeField] private EnemySpawnConfig _spawnConfig;

//    private void Start()
//    {
//        foreach (var enemyCount in _spawnConfig.EnemiesCount)
//        {
//            for (int i = 0; i < enemyCount.count; ++i)
//            {
//                var position = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
//                Instantiate(enemyCount.prefab, position, Quaternion.identity);
//            }
//        }
//    }
//}




using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Project;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        EnemyCount[] enemyToSpawn = ProjectContext.Instance.DataService.EnemyCounts;
        foreach (var enemyCount in enemyToSpawn)
        {
            for (int i = 0; i < enemyCount.count; ++i)
            {
                var position = new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f));
                var enemyInstance = Instantiate(enemyCount.prefab, position, Quaternion.identity);
                enemyInstance.GetComponent<HealthController>()?.Init(enemyCount.health);
            }
        }
    }
}




