using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float verticalSpeed;
    public float turnSpeed;
    public float jumpForce;
    private float groundlimit = -5;
    private Animator playerAnimation;
    public GameOverScreen gameOverScreen;
    public FreezeEnemiesPowerUp freezePowerUp;

    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    private Rigidbody playerRB;
    private bool isDead = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        // check if freeze power-up activation
        HandleFreezePowerUp();

        if (isDead)
        {
            return;
        }

        //  horizontal and vertical inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // forward movement
        if (verticalInput > 0)
        {
            playerAnimation.SetBool("frwd", true);
            playerAnimation.SetBool("back", false);
        }
        // backward movement
        else if (verticalInput < 0)
        {
            playerAnimation.SetBool("back", true);
            playerAnimation.SetBool("frwd", false);
        }
        else
        {
            playerAnimation.SetBool("frwd", false);
            playerAnimation.SetBool("back", false);
        }

        // right movement
        if (horizontalInput > 0)
        {
            playerAnimation.SetBool("right", true);
            playerAnimation.SetBool("left", false);
        }
        // left movement
        else if (horizontalInput < 0)
        {
            playerAnimation.SetBool("left", true);
            playerAnimation.SetBool("right", false);
        }
        else
        {
            playerAnimation.SetBool("right", false);
            playerAnimation.SetBool("left", false);
        }

        // moves plyr
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * verticalSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * turnSpeed);

        // jump, but cant double jump
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 0.5f)
        {
            playerAnimation.SetBool("jump", true);
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            playerAnimation.SetBool("jump", false);
        }


        // reset animation
        if (playerAnimation.GetBool("attack") && !Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ResetAttackAnimation());
        }

        // if player falls off edge
        if (transform.position.y <= groundlimit && !isDead)
        {
            playerAnimation.SetBool("death", true);
            Die();
            Debug.Log("Game Over");
        }
    }

    void HandleFreezePowerUp()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (ScoreManager.Instance.canUseFreezePowerUp)
            {
                freezePowerUp.FreezeAllEnemies();
                ScoreManager.Instance.canUseFreezePowerUp = false; 
                Debug.Log("Freeze Power-Up Activated!");
            }
            else
            {
                Debug.Log("Freeze Power-Up not available!");
            }
        }
    }

    IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimation.SetBool("attack", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            Die();
        }
    }

    void SummonFireball()
    {
        if (fireballPrefab != null && fireballSpawnPoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
            Rigidbody fireballRB = fireball.GetComponent<Rigidbody>();

            if (fireballRB != null)
            {
                fireballRB.useGravity = false;
                playerAnimation.SetBool("attack", true);
                fireballRB.AddForce(fireballSpawnPoint.forward * 70f, ForceMode.Impulse);
            }
            else
            {
                playerAnimation.SetBool("attack", true);
            }
        }
    }

    void Die()
    {
        isDead = true;
        playerAnimation.SetBool("death", true);
        playerRB.velocity = Vector3.zero;
        playerAnimation.SetBool("frwd", false);
        playerAnimation.SetBool("back", false);
        playerAnimation.SetBool("right", false);
        playerAnimation.SetBool("left", false);
        Debug.Log("Player has died!");
        int finalScore = ScoreManager.Instance.GetScore();
        gameOverScreen.Setup(finalScore);
    }
}



