using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    private float speed = 50;
  
    public void Move(Vector3 movement)
    {

        movement *= speed * Time.deltaTime;
        //limit paddle - y position
        if (movement.y < 0)
            if (transform.position.y > -25f)
                transform.Translate(0f, movement.y, 0f);
        //limit paddle + y position
        if(movement.y > 0)
            if (transform.position.y < 25f)
                transform.Translate(0f, movement.y, 0f);


    }

}
