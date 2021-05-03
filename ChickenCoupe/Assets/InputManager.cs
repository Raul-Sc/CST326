using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Movement player;
    private void Start()
    {
      player = GetComponent<Movement>();
  
    }
    private void Update()
    {
        //transform.position = parent.position;
        if (Input.GetKey(KeyCode.D))
        {
            player.MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            player.MoveFoward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.MoveBack();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            player.Jump();
        }
       
    }
}
/*
class InputManager
    Data Members:

        Gun gun;
        Movement movement;
    
    Functions:
        Update(); //listen for key presses and responed accordinally
*/

      