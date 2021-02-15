using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Game game;
    [SerializeField] Paddle leftPaddle;
    [SerializeField] Paddle rightPaddle;
    [SerializeField] GameObject powerUpDouble;
    [SerializeField] GameObject powerUpSpeed;
    //fx 
    [SerializeField] ParticleSystem particles;

    [SerializeField] AudioClip paddleSFX;
    [SerializeField] AudioClip wallSFX;
    [SerializeField] AudioClip scoreSFX;
    [SerializeField] AudioClip doubleUp;
    [SerializeField] AudioClip speedUp;

    [SerializeField] GameObject RightScoredLight;
    [SerializeField] GameObject LeftScoredLight;

    private void Start()
    {
        TurnOffLights();
    }
    // Handles Ball velocity, visuals and sound
    private void OnCollisionEnter(Collision collision)
    { 
        particles.GetComponent<ParticleSystem>().Play();

        ball.speed += 2;
        //padle(s) hit locations
        if (collision.gameObject.name == "LeftTop")
        {
            ball.xVelocity = 1;
            ball.yVelocity = 1;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);
        }

        else if (collision.gameObject.name == "LeftMid")
        {
            ball.xVelocity = 1;
            ball.yVelocity = 0;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);
        }

        else if (collision.gameObject.name == "LeftBottom")
        {
            ball.xVelocity =  1;
            ball.yVelocity = -1;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);
        }
        if (collision.gameObject.name == "RightTop")
        {
            ball.xVelocity = -1;
            ball.yVelocity = 1;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);
        }

        else if (collision.gameObject.name == "RightMid")
        {
            ball.xVelocity = -1;
            ball.yVelocity = 0;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);
        }

        else if (collision.gameObject.name == "RightBottom")
        {
            ball.xVelocity = -1;
            ball.yVelocity = -1;

            AudioSource.PlayClipAtPoint(paddleSFX, Camera.main.transform.position, .1f);

        }
        // top and bottom walls
        else if (collision.gameObject.name == "TopWall" || collision.gameObject.name == "BottomWall")
        {
            ball.yVelocity *= -1;

            AudioSource.PlayClipAtPoint(wallSFX, Camera.main.transform.position, .1f);
        }
        //goals
        else if (collision.gameObject.name == "LeftGoal" || collision.gameObject.name == "RightGoal")
        {
            //turn off particles
            particles.GetComponent<ParticleSystem>().Pause();
            particles.GetComponent<ParticleSystem>().Clear();
            ball.speed = 0;
            if (collision.gameObject.name == "LeftGoal")
            {
                RightScoredLight.SetActive(true);
            }
            else
            {
                LeftScoredLight.SetActive(true);

            }
            game.UpdateScore();

            AudioSource.PlayClipAtPoint(scoreSFX, Camera.main.transform.position, .1f);
            Invoke(nameof(TurnOffLights), 0.25f);
     
        }
    }


    // Power Ups
    private void OnTriggerEnter(Collider other)
    {   //valid if greater than initial speed
        if (ball.speed > 20)
        {
            if (other.name == "DoublePowerUp")
            {
                AudioSource.PlayClipAtPoint(doubleUp, Camera.main.transform.position, .1f);
                if (ball.xVelocity == 1)
                {
                    leftPaddle.transform.localScale = new Vector3(1, 12, 1);
                    Invoke(nameof(resetLeftPaddle), 10);
                }
                if(ball.xVelocity == -1)
                {
                    rightPaddle.transform.localScale = new Vector3(1, 12, 1);
                    Invoke(nameof(resetRightPaddle), 10);
                }

                powerUpDouble.SetActive(false);
            }
            if(other.name == "SpeedPowerUp")
            {
                AudioSource.PlayClipAtPoint(speedUp, Camera.main.transform.position, .1f);
                ball.speed = 40;
                powerUpSpeed.SetActive(false);
            }
        }
    }
    void TurnOffLights()
    {
        RightScoredLight.SetActive(false);
        LeftScoredLight.SetActive(false);
    }
    private void resetLeftPaddle()
    {
        leftPaddle.transform.localScale = new Vector3(1, 6, 1);
    }
    private void resetRightPaddle()
    {
        rightPaddle.transform.localScale = new Vector3(1, 6, 1);
    }

}
