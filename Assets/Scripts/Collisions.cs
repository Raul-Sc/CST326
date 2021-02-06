using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public Ball ball;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            //padle(s) hit locations
            if (this.name == "Top")
            {
                ball.xVelocity *= -1;
                ball.yVelocity = 1;
            }

            if (this.name == "Mid")
            {
                ball.xVelocity *= -1;
                ball.yVelocity = 0;
            }
            if (this.name == "Bottom")
            {
                ball.xVelocity *= -1;
                ball.yVelocity = -1;
            }
            // top and bottom boundries
            if (this.name == "Boundry")
            {
                ball.yVelocity *= -1;
            }


        }

    }
}
