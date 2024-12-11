using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayerhand : MonoBehaviour
{
    public GameObject player;

    void Start()
    {

    }

  
    void Update()
    {
        //where the position the fireball is supposed to spawn at, inside the wizard
        transform.position = player.transform.position + player.transform.forward * 1.0f + player.transform.up * 1.5f;
    }
}

