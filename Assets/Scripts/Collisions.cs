using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Game game;
    [SerializeField] ParticleSystem particles;
  
    private void OnCollisionEnter(Collision collision)
    {
        
        particles.GetComponent<ParticleSystem>().Play();

        ball.speed += 2;
        //padle(s) hit locations
        if (collision.gameObject.name == "LeftTop")
        {
            ball.xVelocity = 1;
            ball.yVelocity = 1;
        }

        else if (collision.gameObject.name == "LeftMid")
        {
            ball.xVelocity = 1;
            ball.yVelocity = 0;
            
        }

        else if (collision.gameObject.name == "LeftBottom")
        {
            ball.xVelocity =  1;
            ball.yVelocity = -1;
            
        }
        if (collision.gameObject.name == "RightTop")
        {
            ball.xVelocity = -1;
            ball.yVelocity = 1;
            
        }

        else if (collision.gameObject.name == "RightMid")
        {
            ball.xVelocity = -1;
            ball.yVelocity = 0;
           
        }

        else if (collision.gameObject.name == "RightBottom")
        {
            ball.xVelocity = -1;
            ball.yVelocity = -1;
        
        }
        // top and bottom boundries
        else if (collision.gameObject.name == "TopWall" || collision.gameObject.name == "BottomWall")
        {
            ball.yVelocity *= -1;
        }
        //goals
        else if (collision.gameObject.name == "LeftGoal" || collision.gameObject.name == "RightGoal")
        {
            //turn off particles
             particles.GetComponent<ParticleSystem>().Pause();
             particles.GetComponent<ParticleSystem>().Clear();

            ball.speed = 0;
            game.UpdateScore();
        }
    }

}
