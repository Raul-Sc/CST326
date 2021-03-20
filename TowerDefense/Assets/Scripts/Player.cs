using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int purse;
    readonly int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        purse = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
                purse += enemy.GetBounty(damage);
                print("Purse amount: " + purse);
            } 
        }
    }

    /*
    class Player
        functions:
        shoot()// Shots a ray if enemy hit, try and collect our bounty

        Data Members
        int purse;//how much money a player gets from collectiing bounties
        int damage;//how much damage it deals


    */
}
