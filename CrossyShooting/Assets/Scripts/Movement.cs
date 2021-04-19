using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
  

    public void MoveRight()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveLeft()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveFoward()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }
    public void MoveBack()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
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