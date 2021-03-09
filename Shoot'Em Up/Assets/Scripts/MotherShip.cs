using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotherShip : MonoBehaviour
{
    [SerializeField] Game game;

    //Our enemy info size & formation
    public GameObject enemy;
    readonly int size = 25;
    readonly int rowSize = 5;
    public int alive;
    public Enemy[] pawns;

    //movement info
    float speed = 1.5f;
    public bool makeMove;
    public float pos;

    //Firing information
    private bool[] shooters;
    bool canFire;
    public float fireRate = 1;
    public float bulletSpeed = -10;

    bool beginPlay = false;

    
    private void Start()
    {
        speed = 1.5f;
        makeMove = false;
        canFire = true;
    }
    private void Update()
    {
        if (beginPlay)
        {
            Listen();
            FindShooters();
            if (canFire)
                Fire();
        }
    }
    public void SpawnAndAssign()
    {
        
        pawns = new Enemy[size+1];
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
        //spawn 4 type of enemy 
        GameObject temp2 = Instantiate(enemy, transform.position + new Vector3(x, y, 0), Quaternion.identity);
        pawns[size] = pawns[size] = temp2.GetComponent<Enemy>();
        pawns[size].tag = "?PTS";
        pawns[size].transform.position = new Vector3(-60, 20, 0);
        pawns[size].MoveRight(5f);
        MoveAllLeft();
        beginPlay = true;

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
        //start at column 0
        for (int j = 0; j < rowSize; j++)
        {
            int i = j;//go up the column until not null found
            bool found = false;
            while (i < (size - rowSize) && !found )
            {
                if (pawns[i] != null)
                    found = true;
                else
                {
                    shooters[i] = false;
                    i += rowSize;
                }
            }
            if(found)
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
    public void  PawnDeath(int index)
    {
        alive--;
        game.UpdateScore(pawns[index].tag.ToString());
        pawns[index] = null;
        if((size - alive)% 5== 0)
        {
            speed++;
        }
        if (alive < 5)
            speed++;
        print("speed : " + speed);
    }
    public void DestroyAll()
    {
        beginPlay = false;
        for (int i = 0; i < size + 1; i++)
        {
            if (pawns[i] != null)
                Destroy(pawns[i].gameObject);
        }
    }

}
