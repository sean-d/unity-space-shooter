using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool loopingWaves = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } 
        while (loopingWaves);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnWaveEnemies(currentWave));
        }
    }
    private IEnumerator SpawnWaveEnemies(WaveConfig theConfig)
    {
        for (int i = 0; i < theConfig.GetNumberOfSpawns(); i++)
        {
            var currentEnemy = Instantiate(theConfig.GetEnemyPrefab(),
                        theConfig.GetPathWaypoints()[0].transform.position,
                        Quaternion.identity);
            //this way we control wave settings in the waveconfigs (Assets/Waves/waveconfigs) 
            //rather than variables in the scripts. 
            currentEnemy.GetComponent<EnemyPathing>().SetWaveConfig(theConfig);

            yield return new WaitForSeconds(theConfig.GetTimeBetweenSpawn());
            
        }
    }
}
