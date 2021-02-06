using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    //keep score
    int leftPlayer = 0;
    int rightPlayer = 0;
    [SerializeField] Text leftScore;
    [SerializeField] Text rightScore;
    // Update is called once per frame
    public int xVelocity = 1;
    public int yVelocity = 1;
    public int speed = 10;

    void SpawnBall()//will spawn to person who got scored on
    {
        //pick random cordinate on Y axis
        var y = Random.Range(-15.0f, 15.0f);
        var temp = new Vector3(0, y, 0);
        this.transform.position = temp;
        // random y velocity 
        if ((int)y % 2 == 0)
        {
            this.yVelocity *= -1;
        }
        //start the ball
        this.speed = 10;
    }

    //move ball
    void Update()
    {
        // x axis
        transform.Translate(Vector3.right * Time.deltaTime * xVelocity * speed);
        //y axis
        transform.Translate(Vector3.up * Time.deltaTime * yVelocity * speed);
    }
    public void UpdateScore()
    {
        string scored = " ";
        if (xVelocity == 1)
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
            leftPlayer = 0;
            rightPlayer = 0;
        }
        Invoke(nameof(SpawnBall), 2.0f);
    }
    bool GameOver()
    {
        if (leftPlayer == 11 || rightPlayer == 11)
            return true;
        return false;
    }
}
