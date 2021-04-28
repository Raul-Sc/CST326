using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Movement movement;
    Gun gun;
    float mySpeed = 6f;
    [SerializeField] Health myHealth;

    private void Awake()
    {
        GetComponent<Trigger>().PlayerHitEvent.AddListener(delegate { TakeDamage(); });
        movement = GetComponent<Movement>();
        movement.speed = mySpeed;
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
     
        if(gun.magSize > 0)
            gun.Fire();
    }
    public void Reload()
    {
        gun.Reload();
    }
    public void TakeDamage()
    {

        myHealth.life -= 34;
        if (myHealth.life <= 0)
        {
            print("GAME OVER");
            //Destroy(gameObject);
        }
    }
}
/*
 Class Player
    Data Members:
        Movement movement;
        Gun gun;
        float mySpeed;

    Functions:

        MoveLeft();
        MoveRight();
        MoveFoward();
        MoveBack();
        Fire();

 * 
 */
