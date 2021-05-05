using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawn = .5f;
    [SerializeField] float spawnRandomizer = .3f;
    [SerializeField] int numberOfSpawns = 10;
    [SerializeField] float enemyMoveSpeed = 2f;


public GameObject GetEnemyPrefab() { return enemyPrefab; }
public GameObject GetPathPrefab() { return pathPrefab; }
public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }
public float GetSpawnRandomizer() { return spawnRandomizer; }
public float GetNumberOfSpawns() { return numberOfSpawns; }
public float GetEnemyMoveSpeed() { return enemyMoveSpeed; }

}

