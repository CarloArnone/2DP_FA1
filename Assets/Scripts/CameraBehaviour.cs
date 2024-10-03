using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private Player player;
    
    // Update is called once per frame
    void Update()
    {
        player.OnPlayerMove += FollowPlayer;
    }
    
    void FollowPlayer(Vector3 playerPosition)
    {
        transform.position = new Vector3(playerPosition.x, playerPosition.y, -10);
    }
    
    
    
    
}
