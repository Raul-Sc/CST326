using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    // Ball Properties
    public int xVelocity = 1;
    public int yVelocity = 1;
    public int speed = 10;
    private void Start()
    {
        //SpawnBall();
    }
    public void SpawnBall()//will spawn to person who got scored on
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

}
