using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotherShip : MonoBehaviour
{
    //Our enemy info size & formation
    public GameObject enemy;
    readonly int size = 25;
    readonly int rowSize = 5;
    public int alive;
    public Enemy[] pawns;
    //movement info
    public float speed = 1;
    public bool makeMove;
    public float pos;

    //Firing information
    private bool[] shooters;
    bool canFire;
    public float fireRate = 1;
    public float bulletSpeed = -10;
    private void Awake()
    {
        SpawnAndAssign();
    }
    private void Start()
    {
        makeMove = false;
        canFire = true;
        MoveAllLeft();
    }
    private void Update()
    {
        Listen();
        FindShooters();
        if (canFire)
            Fire();
    }
    private void SpawnAndAssign()
    {
        
        pawns = new Enemy[size];
        shooters = new bool[size];
        alive = size;
        int x = 0;
        int y = 0;
        for (int i = 0; i < size; i++)
        {
            shooters[i] = false;
            GameObject temp = Instantiate(enemy, transform.position + new Vector3(x, y, 0), Quaternion.identity);
            pawns[i] = temp.GetComponent<Enemy>();
            if (i / rowSize == 0) pawns[i].tag = "10PTS";
            if (i / rowSize == 1) pawns[i].tag = "10PTS";
            if (i / rowSize == 2) pawns[i].tag = "20PTS";
            if (i / rowSize == 3) pawns[i].tag = "20PTS";
            if (i / rowSize == 4) pawns[i].tag = "30PTS";
            pawns[i].index = i;

            x -= 3;
            if (i % rowSize == (rowSize-1))
            {
                x = 0;
                y += 3;
            }
        }
    }
    void Listen()
    {
        if (makeMove)
        {
            MoveAllDown();
            if (pos < 0)
                MoveAllRight();
            else
                MoveAllLeft();
            makeMove = false;
        }



    }
    private void MoveAllLeft()
    {
        for(int i = 0; i < size; i++)
        {
            if(pawns[i] != null)
             pawns[i].MoveLeft(speed);
        }
    }
    private void MoveAllRight()
    {
        for (int i = 0; i < size; i++)
        {
            if (pawns[i] != null)
                pawns[i].MoveRight(speed);
        }
    }
    private void MoveAllDown()
    {
        for (int i = 0; i < size; i++)
        {
            if (pawns[i] != null)
                pawns[i].MoveDown();
        }
    }
    void FindShooters()
    {
        for (int j = 0; j < rowSize; j++)
        {
            int i = j;
            while (pawns[i] == null && i < size - rowSize)
            {
                shooters[i] = false;
                i += rowSize;
            }
            pawns[i].canShoot = true;
            shooters[i] = true;
        }
            

    }
    void Fire()
    {
        canFire = false;
        System.Random rand = new System.Random();
        int index = rand.Next(size);
        while (!shooters[index])
            index = rand.Next(rowSize);
        pawns[index].Fire(bulletSpeed);
        StartCoroutine(FireRate());


    }
    IEnumerator FireRate()
    { 
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

}
