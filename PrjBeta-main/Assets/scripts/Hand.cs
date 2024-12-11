using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject fireBallSpawnPoint;
    [SerializeField]
    private GameObject sphere;
    private GameObject skeleton;
    private Animator playerAnimation;
    private Transform playerTransform; 


    void Start()
    {
        playerAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        //mouse click or ctrl
        if (Input.GetButtonDown("Fire1"))
        {
            //player animation for attack
            playerAnimation.SetBool("attack", true);
            Instantiate(sphere, fireBallSpawnPoint.transform.position, fireBallSpawnPoint.transform.rotation);
        }
        //for old powerup
        /*spawn power up on click
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            playerAnimation.SetBool("summon", true);
            Vector3 spawnPosition = playerTransform.position + new Vector3(2f, 0f, 2f);
            Instantiate(skeleton, spawnPosition, playerTransform.rotation);
        }
        */
    }
}