using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Ball ball;

    //keep score
    [SerializeField] Text leftScore;
    [SerializeField] Text rightScore;
    int leftPlayer = 0;
    int rightPlayer = 0;

    void StartGame()
    {
        leftPlayer = 0;
        rightPlayer = 0;
        leftScore.text = leftPlayer.ToString();
        rightScore.text = rightPlayer.ToString();
        ball.SpawnBall();
    }

    public void UpdateScore()
    {
        string scored = " ";
        if (ball.xVelocity == 1)
        {
            leftPlayer++;
            scored = "Left";
        }

        else
        {
            rightPlayer++;
            scored = "Right";
        }
        Debug.Log("GOOALL!!! by " + scored + '\n'
            + "LEFT: " + leftPlayer + " RIGHT: " + rightPlayer);
        leftScore.text = leftPlayer.ToString();
        rightScore.text = rightPlayer.ToString();
        if (GameOver())
        {
            Debug.Log(scored + " Player WON!!!");
            Invoke(nameof(StartGame), 2);
        }
        else
            ball.SpawnBall();
    }
    bool GameOver()
    {
        if (leftPlayer == 11 || rightPlayer == 11)
            return true;
        return false;
    }
    private void Update()
    {
        //respawn ball if it leaves bounds
        //Goals bounds
        if(ball.transform.position.x > 52 || ball.transform.position.x < -52)
        {
            UpdateScore();
            ball.SpawnBall();
        }
        //top and bottom
        if(ball.transform.position.y > 31 || ball.transform.position.y < -31)
        {
            ball.SpawnBall();
        }
    }
}
