using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Movement movement;
    Gun gun;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        gun = transform.GetComponentInChildren<Gun>();
    }
    private void Update()
    {
        //transform.position = parent.position;
        if (Input.GetKey(KeyCode.D))
        {
            movement.MoveRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.MoveLeft();
        }
        if (Input.GetKey(KeyCode.W))
        {
            movement.MoveFoward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.MoveBack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gun.Fire();
        }
    }
}
/*
class InputManager
    Data Members:

        Gun gun;
        Movement movement;
    
    Functions:
        Update()//listen for key presses and responed accordinally
*/

      