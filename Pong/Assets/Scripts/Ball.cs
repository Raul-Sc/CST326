using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    // Ball Properties
    public int xVelocity = 1;
    public int yVelocity = 1;
    public int speed = 20;
    private const int INITIAL_SPEED = 20;
  
    public void SpawnBall()//will spawn to person who got scored on
    {
        //pick random cordinate on Y axis
        var y = Random.Range(-25.0f, 25.0f);
        var temp = new Vector3(0, y, 0);
        this.transform.position = temp;
        // random y velocity 
        this.yVelocity = ((int)(y % 3)) - 1;
        //start the ball
        this.speed = INITIAL_SPEED;
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
