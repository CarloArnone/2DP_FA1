using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Vector3> OnPlayerMove;
    
    
    // Update is called once per frame
    void Update()
    {
        
        // Rotate the player pointing to the mouse 2d position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        Vector3 direction2D = new Vector3(direction.x, direction.y, 0);
        // Move the player
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += direction2D.normalized * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -direction2D.normalized * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //Orthogonal direction counter clockwise
            Vector3 leftDirection = new Vector3(-direction2D.y, direction2D.x, 0);
            
            transform.position +=  leftDirection.normalized * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Orthogonal direction clockwise
            Vector3 rightDirection = new Vector3(direction2D.y, -direction2D.x, 0);
            
            transform.position += rightDirection.normalized * Time.deltaTime;
        }
        
        OnPlayerMove?.Invoke(transform.position);
        
    }
}