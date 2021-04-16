using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    int magSize = 10;
    //float fireRate = 1f;

    void Fire()
    {
        if (magSize>0) {
            Instantiate(bullet, transform.position, Quaternion.identity);
            magSize--;
          }

    }
    void Reload()
    {
        print("NEED TO RELOAD!");
    }
    private void Update()
    {
        if (magSize <= 0)
        {
            Reload();
        }
        if (Input.GetKeyDown("space"))
        {
            Fire();
        }
    }
}
/*
Class Gun
    Data Members
    
        Projectile bullet;
        Int magSize;
        float fireRate;
        bool empty 
    Functions
        Fire()
        Reload()
        

    
    
 */