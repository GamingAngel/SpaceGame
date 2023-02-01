using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnTransform;

    [SerializeField] private float firstSpawnDelay;

    [Serializable]
    public struct SpawnEnemyWave
    {
        public int enemyIndex;
        public int spawnIndex;
        public float spawnDelay;

        
    }
    public SpawnEnemyWave[] wave;

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(firstSpawnDelay);

        for (int i = 0; i < wave.Length; i++)
        {
            Instantiate(enemies[wave[i].enemyIndex], spawnTransform[wave[i].spawnIndex].position, enemies[wave[i].enemyIndex].transform.rotation);
   
            yield return new WaitForSeconds(wave[i].spawnDelay); 
        }
       
    }

    private void Start()
    {
       StartCoroutine(SpawnEnemy());
    }

 

}
