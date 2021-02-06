using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{ 
    public float speed = 1;
  
    public void Move(Vector3 movement)
    {
        movement *= speed * Time.deltaTime;
        transform.Translate(0f, movement.y, 0f);
    }
  

}
