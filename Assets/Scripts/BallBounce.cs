using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
   public GameObject hitSFX;
   public BallMovement ballMovement;
   public ScoreManager scoreManager;

   public void Bounce(Collision2D collision)
   {
        // To know position of ball 
        Vector3 ballPosition = transform.position;
        // To get position of the object ball had collision with 
        Vector3 racketPosition = collision.transform.position;
        // To get the postion of the part of racket did the ball collided 
        float racketHeight = collision.collider.bounds.size.y;

        // To check ball is hit by player 1 or player 2 
        float positionX;
        if(collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY= (ballPosition.y - racketPosition.y)/racketHeight;

        ballMovement.IncreasedCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
   }

    // To detect collision
   private void OnCollisionEnter2D(Collision2D collision)
   {
    // To detect whether collision is with palyer 1 Or player 2 
    if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
    {
        Bounce(collision);
    }

    else if (collision.gameObject.name == "Right Border")
    {
        scoreManager.Player1Goal();
        ballMovement.player1Start = false;
        StartCoroutine(ballMovement.Launch());
    }

    else if (collision.gameObject.name == "Left Border")
    {
        scoreManager.Player2Goal();
        ballMovement.player1Start = true;
        StartCoroutine(ballMovement.Launch());
    }
    
    Instantiate(hitSFX , transform.position, transform.rotation);

   }
}
