using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotherShip : MonoBehaviour
{
    public GameObject Group;
    public int alive;
    public int initial;
    public bool makeMove = false;
    private bool canFire;
    public int fireRate = 1;
    public float xpos;
    public float speed = 1;

    public bool[] shooters = new bool[25];
 

    private void Start()
    {
        alive = 0;
        canFire = true;
   
        foreach (Transform parent in Group.transform)
        {
            foreach (Transform child in parent.transform)
            {
                child.gameObject.GetComponent<Enemy>().index = alive;
                child.gameObject.GetComponent<Enemy>().MoveLeft(speed);
                if(alive >= 20)
                {
                    shooters[alive] = true;
                }

                alive++;
            }
        }
        initial = alive;
    }

    private void Update()
    {
        Listen();
        if (canFire)
           Fire(FindaShooter());
    }
    //if child hits boundry, mothership makes all enemies move
    void Listen()
    {
        if (makeMove)
        { 
            foreach (Transform parent in Group.transform)
                foreach (Transform child in parent.transform)
                    child.gameObject.GetComponent<Enemy>().MoveDown();
            if (xpos < 0)
            {
                foreach (Transform parent in Group.transform)
                    foreach (Transform child in parent.transform)
                        child.gameObject.GetComponent<Enemy>().MoveRight(speed);
            }
            else
            {
                foreach (Transform parent in Group.transform)
                    foreach (Transform child in parent.transform)
                        child.gameObject.GetComponent<Enemy>().MoveLeft(speed);
            }
            makeMove = false;
        }

        

    }
    int FindaShooter()
    {
        System.Random rand = new System.Random();
        int index =  rand.Next(initial);
        while (!shooters[index])
            index = rand.Next(initial);
        return index;
    }
    void Fire(int index)
    {
        canFire = false;
        int row = index / 5;
        int col = index % 5;
        Group.transform.GetChild(row).GetChild(col).GetComponent<Enemy>().Fire();
        StartCoroutine(FireRate());


    }
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
