using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Movement movement;
    Gun gun;

    float mySpeed = 6f;
    [SerializeField] Health myHealth;


    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canMoveBack = true;
    public bool canShoot = true;//while not in cover

    public int score;
    private void Awake()
    {
        score = 0;
        GetComponent<Trigger>().PlayerHitEvent.AddListener(delegate { TakeDamage(); });
        movement = GetComponent<Movement>();
        movement.speed = mySpeed;
        gun = GetComponentInChildren<Gun>();
    }
    public void MoveLeft()
    {
        if(canMoveLeft)
            movement.MoveLeft();
    }
    public void MoveRight()
    {
        if(canMoveRight)
         movement.MoveRight();
    }
    public void MoveFoward()
    {
        movement.MoveFoward();
    }
    public void MoveBack()
    {
        if(canMoveBack)
            movement.MoveBack();
    }
    public void Shoot()
    {
        if(canShoot)
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
            
            transform.localScale = new Vector3(1, .1f, 1);
            MoveBack();
            GetComponentInParent<Game>().Restart();
        }
    }
    public void AddScore()
    { 
        score += 1;
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
