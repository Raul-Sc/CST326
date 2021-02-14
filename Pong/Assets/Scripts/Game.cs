using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] GameObject powerUpDouble;

    //keep score
    [SerializeField] Text leftScore;
    [SerializeField] Text rightScore;


    int leftPlayer = 0;
    int rightPlayer = 0;

    int rightStreak = 0;
    int leftStreak = 0;
    int randomPower = 0;

    private void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        //reset everything

        //powerUpDouble
        randomPower = Random.Range(3,9);//random digit 
        powerUpDouble.SetActive(false);


        ResetScoreColor(leftScore);
        ResetScoreColor(rightScore);
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
        if ((leftPlayer + rightPlayer + 1) % randomPower == 0) 
        {
            var y = Random.Range(-25.0f, 25.0f);
            var temp = new Vector3(0, y, 0);
            powerUpDouble.transform.position = temp;
            powerUpDouble.SetActive(true);
        }
        string scored = " ";
        //left player scored
        if (ball.xVelocity == 1)
        {
            leftPlayer++;
            scored = "Left";

            leftStreak++;
            rightStreak = 0;
            // unless match point
            if(rightPlayer != 10 )
                ResetScoreColor(rightScore);
            if (leftStreak == 3 || leftPlayer > 9)
                leftScore.color = Color.red;
        }
        // right player scored
        else
        {
            rightPlayer++;
            scored = "Right";

            rightStreak++;
            leftStreak = 0;
            //unless match point
            if(leftPlayer != 10)
                ResetScoreColor(leftScore);
            if (rightStreak == 3 || rightPlayer > 9)
                rightScore.color = Color.red;


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
    void ResetScoreColor(Text score)
    {
        score.color = Color.white;
    }
  
}
