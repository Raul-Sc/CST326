using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    bool jumping = false;
    float waitTime = .1f;
     Quaternion initial;
    private void Awake()
    {
        initial = transform.rotation;
    }
    public void MoveRight()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y +90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveLeft()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }
    public void MoveFoward()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,speed * Time.deltaTime,Space.World);
    }
    public void MoveBack()
    {
        Jump();
        Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, initial.eulerAngles.y - 180, transform.rotation.eulerAngles.z);
        transform.rotation = newRotation;
        transform.Translate(0,0,-speed * Time.deltaTime, Space.World);
    }
    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;
            transform.position = new Vector3(transform.position.x, 2, transform.position.z);
            StartCoroutine(Floor());
        }
    }
    IEnumerator Floor()
    {
        yield return new WaitForSeconds(waitTime);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        StartCoroutine(SetJump());
    }
    IEnumerator SetJump()
    {
        yield return new WaitForSeconds(waitTime);
        jumping = false;
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