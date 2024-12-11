using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemiesPowerUp : MonoBehaviour
{
    public void FreezeAllEnemies()
    {
        // powerup lasts only for 5 seconds
        StartCoroutine(FreezeEnemiesForDuration(5f));
    }

    private IEnumerator FreezeEnemiesForDuration(float duration)
    {
        Enemy.speed = 0f;

        yield return new WaitForSeconds(duration);

        //this means whenever u use power up the speed is set to default and not the speed prior to the powerup,
        //so the +0.5f appended at every 8th point so far is reset, this is so its easier for the player to enjoy the game
        Enemy.speed = 2f; 
        Debug.Log("Enemies unfrozen.");
    }
}
