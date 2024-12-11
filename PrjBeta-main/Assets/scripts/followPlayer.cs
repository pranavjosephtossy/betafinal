using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        //camera follows player, fixed
        transform.position = player.transform.position+ new Vector3(0,5,-10);
    }
}
