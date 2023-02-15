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
        [Range(0f, 5f)] public int enemyIndex;
        [Range(0f, 4f)] public int spawnIndex;
        [Range(0f, 10f)] public float spawnDelay;        
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

       EnemyShip.enemyCount= wave.Length;
  
       StartCoroutine(SpawnEnemy());

    }
}
