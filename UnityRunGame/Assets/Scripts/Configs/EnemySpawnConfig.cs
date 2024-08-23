using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySpawnConfig", menuName = "MyProject/EnemySpawnConfig")]
public class EnemySpawnConfig : ScriptableObject
{
    public EnemyCount[] EnemiesCount;
}

[Serializable]
public struct EnemyCount
{
    public int count;
    public int health;
    public GameObject prefab;
}