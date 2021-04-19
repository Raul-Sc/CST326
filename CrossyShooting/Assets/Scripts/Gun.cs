using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    ParticleSystem spark;
    Light flash;
    int magSize = 100;
    //float fireRate = 1f;
    private void Awake()
    {
        spark = GetComponentInChildren<ParticleSystem>();
        flash = GetComponentInChildren<ParticleSystem>().GetComponentInChildren<Light>();
        flash.enabled = false;
    }
    public void Fire()
    {
        if (magSize>0) {
            flash.enabled = true;
            spark.Play();
            flash.enabled = false;
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
        ParticleSystem flash;
        int magSize;
        float fireRate;

    Functions:

        Update();//auto reload 
        Fire();
        Reload();
        

    
    
 */