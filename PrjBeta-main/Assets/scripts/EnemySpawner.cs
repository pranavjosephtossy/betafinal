using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int maxEnemies = 10;
    public float spawnInterval = 3f;

    private float difficultyTimer = 0f;
    private float difficultyInterval = 30f; 

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            if (enemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);

            difficultyTimer += spawnInterval;

            if (difficultyTimer >= difficultyInterval)
            {
                difficultyTimer = 0;
                IncreaseDifficulty();
            }
        }
    }

    void SpawnEnemy()
    {
        xPos = Random.Range(12, 38);
        zPos = Random.Range(3, 22);
        int indexRandomEnemoy = Random.Range(0, enemy.Length);  
        GameObject theEnemy = enemy[indexRandomEnemoy];
        GameObject enemySpawned = Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
        enemySpawned.AddComponent<Enemy>();
        enemySpawned.GetComponent<Enemy>().spawner = this;
        enemyCount++;
    }

    public void DecrementEnemyCount()
    {
        enemyCount--;
    }

    public void IncreaseDifficulty()
    {
        Debug.Log("Enemies increased");
        spawnInterval = Mathf.Max(0.2f, spawnInterval - 0.5f); 
        maxEnemies += 5; 
        Enemy.speed += 0.1f; 
    }

    
}

