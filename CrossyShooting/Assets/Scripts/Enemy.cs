using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Movement movement;
    Gun gun;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        gun = GetComponentInChildren<Gun>();
    }
    public void MoveLeft()
    {
        movement.MoveLeft();
    }
    public void MoveRight()
    {
        movement.MoveRight();
    }
    public void MoveFoward()
    {
        movement.MoveFoward();
    }
    public void MoveBack()
    {
        movement.MoveBack();
    }
    public void Shoot()
    {
        gun.Fire();
    }

}
/*
 class Enemy
    Data members:
        Gun gun;
        Movement movent;
 Functions:

        MoveLeft();
        MoveRight();
        MoveFoward();
        MoveBack();
        Fire();


 */