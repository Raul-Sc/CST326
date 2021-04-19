using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    Movement movement;
    Gun gun;
    Health myHealth;
    GameObject target = null;

    public UnityEvent DeathEvent;

    private void Awake()
    {
        myHealth = GetComponentInChildren<Health>();
        GetComponent<Trigger>().HitEvent.AddListener(delegate { TakeDamage(); });
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
    public void TakeDamage()
    {
        myHealth.life -= 34;
        if (myHealth.life <= 0)
        {
            DeathEvent.Invoke();
            Destroy(gameObject);
        }
    }
    public void SetTarget(GameObject player)
    {
        target = player;
        Shoot();
    }

}
/*
 class Enemy
    Data members:
        Gun gun;
        Movement movent;
        Health myHealth;
        UnityEvent DeathEvent;
        GameObject target = null;

 Functions:

        MoveLeft();
        MoveRight();
        MoveFoward();
        MoveBack();
        Fire();

        TakeDamage();


 */