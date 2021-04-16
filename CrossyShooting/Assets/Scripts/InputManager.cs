using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Player player;

    private void Start()
    {
      player = GetComponent<Player>();
  
    }
    private void Update()
    {
        //transform.position = parent.position;
        if (Input.GetKey(KeyCode.D))
        {
            player.MoveRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.MoveLeft();
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.MoveFoward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.MoveBack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            player.Shoot();
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

      