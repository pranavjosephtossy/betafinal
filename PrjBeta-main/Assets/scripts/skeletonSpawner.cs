using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonSpawner : MonoBehaviour
{
    public GameObject skeleton;  
    private GameObject player;  
    private GameObject enemyTarget;  
    private ScoreManager scoreManager;  

    void Start()
    {
        //get gameObjects 
        player = GameObject.FindGameObjectWithTag("Player");
        enemyTarget = GameObject.FindGameObjectWithTag("Enemy");
        skeleton = GameObject.FindGameObjectWithTag("skeleton");

        //get score from scoreManager
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void SpawnSkeleton()
    {
        /*old powerup
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject skeletonInstance = Instantiate(skeleton, spawnPosition, Quaternion.identity);
        skeletonCtrl skeletonMovement = skeletonInstance.AddComponent<skeletonCtrl>();
        skeletonMovement.target = enemyTarget.transform; 
        Rigidbody rb = skeletonInstance.AddComponent<Rigidbody>();
        */
    }

    Vector3 GetRandomSpawnPosition()
    {
        // random spawn areas for skeletons
        float randomX = Random.Range(16f, 32f);  
        float randomZ = Random.Range(1f, 13f);  
        float y = -4768f;

        return new Vector3(randomX, y, randomZ);
    }


}
