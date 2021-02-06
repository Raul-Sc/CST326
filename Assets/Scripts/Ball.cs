using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Update is called once per frame
    public int xVelocity = 1;
    public int yVelocity = 1;
    public int speed = 10;

    //move ball
    void Update()
    {
        // x axis
        transform.Translate(Vector3.right * Time.deltaTime * xVelocity * speed);
        //y axis
        transform.Translate(Vector3.up * Time.deltaTime * yVelocity * speed);
    }
}
