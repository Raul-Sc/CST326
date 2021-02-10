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

    int rightStreak = 0;
    int leftStreak = 0;

    private void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        resetScoreColor(leftScore);
        resetScoreColor(rightScore);
        rightStreak = 0;
        leftStreak = 0;
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
            leftStreak++;
            rightStreak = 0;
            resetScoreColor(rightScore);
            if (leftStreak == 3)
                leftScore.color = Color.red;
        }

        else
        {
            rightPlayer++;
            scored = "Right";
            rightStreak++;

            resetScoreColor(leftScore);
            if (rightStreak == 3)
                rightScore.color = Color.red;


        }
        Debug.Log("GOOALL!!! by " + scored + '\n'
            + "LEFT: " + leftPlayer + " RIGHT: " + rightPlayer);
     
        leftScore.text = leftPlayer.ToString();
        rightScore.text = rightPlayer.ToString();

        Invoke(nameof(resetScoreColor),.25f);
        
        if (GameOver())
        {
            Debug.Log(scored + " Player WON!!!");
            Invoke(nameof(StartGame), 2);
        }
        else
        {
            ball.SpawnBall();
        }
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
        if (ball.transform.position.y > 31 || ball.transform.position.y < -31)
        {
            ball.SpawnBall();
        }
        //escape app
         if (Input.GetKey("escape"))
         {
                Application.Quit();
         }
    }
    void resetScoreColor(Text score)
    {
        score.color = Color.white;
    }
}
