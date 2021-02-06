using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class Paddle : MonoBehaviour
{ 
    public float speed = 1;

    private InputManager playerInput;

    private void Awake()
    {
        playerInput = GetComponent< InputManager>();
    }
    public void Move()
    {
        Vector3 movement = playerInput.movementInput;
        movement *= speed * Time.deltaTime;
        transform.Translate(0f, movement.y, 0f);
    }

}
