using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
  

    public void MoveRight()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveLeft()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveFoward()
    {
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }
    public void MoveBack()
    {
        transform.Translate(0,0,-speed * Time.deltaTime, Space.World);
    }
   private void Update()
    {
       
    }
}
/*
 Class Movement
    Data members:

        float speed;

     Functions:
        MoveLeft()
        MoveRight()
        MoveFoward()
        MoveBack()
        Update()//temp input handling
        
            
*/