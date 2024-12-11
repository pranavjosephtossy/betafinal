using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public skeletonSpawner skeletonSpawner;
    public EnemySpawner enemySpawner;
    public int score = 0;
    public Text scoreText;

    public bool canUseFreezePowerUp = false; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();

        // grant power-up every 10 kills
        if (score % 10 == 0)
        {
            canUseFreezePowerUp = true;
            Debug.Log("Freeze Power-Up Ready!");
        }

        /* old powerup
        // spawn skeletons and increase difficulty (existing logic)
        if (score % 15 == 0)
        {
            skeletonSpawner.SpawnSkeleton();
        }
        */

        if (score % 8 == 0)
        {
            //this means whenever u use power up, the speed is set to default and not the speed prior to the powerup,
            //so the +0.5f appended at every 8th point so far is reset, this is so its easier for the player to enjoy the game
            Enemy.speed += 0.5f;
        }

        if (score % 10 == 0)
        {
            enemySpawner.IncreaseDifficulty();
        }
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
