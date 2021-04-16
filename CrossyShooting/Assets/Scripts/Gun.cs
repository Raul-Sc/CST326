using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    int magSize = 10;
    //float fireRate = 1f;

    public void Fire()
    {
        if (magSize>0) {
            Instantiate(bullet, transform.position,transform.rotation);
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
    }
}
/*
Class Gun
    Data Members:
    
        GameObject bullet;
        int magSize;
        float fireRate;
        bool empty

    Functions:

        Update()//auto reload 
        Fire()
        Reload()
        

    
    
 */