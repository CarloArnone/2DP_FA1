using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Npc : MonoBehaviour
{
    
    private GameObject _playerObject;
    private Vector3 _offsetFromPlayer;
    private Vector3 _realOffsetFromPlayer;
    private bool _isFollowingPlayer = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //Make NPC follow the player
        _playerObject = other.gameObject;
        
        if(!_isFollowingPlayer)
        {
            _isFollowingPlayer = true;
            print("Player entered" + this.gameObject.name);
            GameManager.Instance.AddPerson(this.gameObject);
            _offsetFromPlayer = GameManager.Instance.getNewPersonOffset();
        
        
            StartCoroutine(FollowPlayer());
        }
        
    }
    
    
    IEnumerator FollowPlayer()
    {
        //Make NPC follow the player
        
        while (_playerObject != null)
        {
            Vector3 direction = _playerObject.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            
            float playerAngle = Quaternion.Angle(_playerObject.gameObject.transform.rotation, transform.rotation);

            _realOffsetFromPlayer =  new Vector3(math.cos(playerAngle), math.sin(playerAngle), 0) * _offsetFromPlayer.magnitude;
            
            transform.position += (direction + _realOffsetFromPlayer).normalized * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
