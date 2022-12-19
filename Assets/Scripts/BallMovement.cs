using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Variables determining speeds of ball at different instances 
    // startSpeed and maxExtraSpeed are the boundary conditions of the ball
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

    // int Variable to keep count of how many times ball hit the racket 
    private int hitCounter = 0;

    // Rigidbody2D variable "rb" 
    private Rigidbody2D rb;
    
    // Start is called before the first frame update and here fetch rigidbody2D from "ball" object
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        // calling Lauch Corountine
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }

    // To call the MoveBall function with coroutine
    public IEnumerator Launch()
    {
        RestartBall();
        // at start of the game 
        hitCounter = 0;
        // To make the game wait for 1 sec before launching the ball so the players can get ready 
        yield return new WaitForSeconds(1);

        if(player1Start == true){
            // Calling MoveBall function , moving ball to the left as x coordinate is set -1
        MoveBall(new Vector2(-1, 0));
        }
      
        else{
            MoveBall(new Vector2(1, 0));
        }
    }

    // Function moveball which takes direction as parameter and facilitates the movement of ball
    public void MoveBall(Vector2 direction)
    {
        direction =direction.normalized;

        // ballSpeed determines the current speed of the ball
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        // Inorder to apply ballSpeed to the physics component of the object "ball" rb.velocity is used
        rb.velocity = direction * ballSpeed;
    }

    public void IncreasedCounter()
    {
       if(hitCounter * extraSpeed < maxExtraSpeed)
       {
        hitCounter++;
       }
        
    }
}
