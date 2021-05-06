using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigs[startingWave];
        
        StartCoroutine(SpawnWaveEnemies(currentWave));

    }

    private IEnumerator SpawnWaveEnemies(WaveConfig theConfig)
    {
        Instantiate(theConfig.GetEnemyPrefab(),
                    theConfig.GetPathWaypoints()[0].transform.position,
                    Quaternion.identity);

        yield return new WaitForSeconds(theConfig.GetTimeBetweenSpawn());
    }
}
