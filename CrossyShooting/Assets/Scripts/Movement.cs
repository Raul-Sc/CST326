using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    Quaternion initial;
    private void Awake()
    {
        initial = transform.rotation;
    }
    public void MoveRight()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y +90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveLeft()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveFoward()
    {
 
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }
    public void MoveBack()
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,-speed * Time.deltaTime, Space.World);
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