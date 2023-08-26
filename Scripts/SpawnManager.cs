using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPowerup();
        SpawnEnemyWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0, 0.5f, 0), powerupPrefab.transform.rotation);
        }

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        }
    }
    void SpawnPowerup()
    {
        int powerupIndex = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[powerupIndex], GenerateSpawnPosition() + new Vector3(0, 0.5f, 0), powerupPrefab[powerupIndex].transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return spawnPos;
    }
}
