using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed = 2f; 
    public EnemySpawner spawner;
    private Vector3 randomDirection;

    void Start()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        StartCoroutine(ChangeDirection());
        
    }

    void Update()
    {
        transform.Translate(randomDirection * speed * Time.deltaTime);
        //destroy ghost if it leaves game area
        if (transform.position.x < 8 || transform.position.x > 41 || transform.position.z < -5 || transform.position.z > 25)
        {
            Destroy(gameObject); 
        }
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        }
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.DecrementEnemyCount();
        }
    }
}
