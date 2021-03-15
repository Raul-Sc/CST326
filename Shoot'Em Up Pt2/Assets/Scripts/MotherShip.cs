using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MotherShip : MonoBehaviour
{
    [SerializeField] Game game;

    //Our enemy info size & formation
    public GameObject enemy;
    int size;
    int rowSize;
    int alive;
    public Enemy[] pawns;

    //movement info
    float speed;
    public bool makeMove;
    public float pos;

    //Firing information
    private bool[] shooters;
    bool canFire;
    float fireRate = 2.4f;
    public float bulletSpeed = -10;

    bool beginPlay = false;

    
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
    public void SpawnAndTag(int setSize, int setRowsize)
    {
    
        size = setSize;
        rowSize = setRowsize;
        speed = game.speed ;

        makeMove = false;
        canFire = true;
        pawns = new Enemy[size+1];
        shooters = new bool[size+1];
        alive = size;
        //positions
        float x = 0;
        float y = 0;
        int row = 0;
        for (int i = 0; i < size; i++)
        {
            shooters[i] = false;
            GameObject temp = Instantiate(enemy, transform.position + new Vector3(x, y, 0), Quaternion.identity);
            pawns[i] = temp.GetComponent<Enemy>();
            if (row % rowSize == 0) pawns[i].tag = "10PTS";
            if (row % rowSize == 1) pawns[i].tag = "10PTS";
            if (row % rowSize == 2) pawns[i].tag = "20PTS";
            if (row % rowSize == 3) pawns[i].tag = "20PTS";
            if (row % rowSize == 4) pawns[i].tag = "30PTS";
            pawns[i].index = i;

            x -= 1.5f;
            if (i % rowSize == (rowSize-1))
            {
                x = 0;
                y += 1.5f;
                row++;
            }
        }
        //spawn 4th type of enemy 
        GameObject temp2 = Instantiate(enemy, transform.position + new Vector3(x, y, 0), Quaternion.identity);
        pawns[size] = pawns[size] = temp2.GetComponent<Enemy>();
        pawns[size].tag = "?PTS";
        pawns[size].transform.position = new Vector3(-50, 10, 0);
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
        int i = 0;
        int j = 0;
        while (i < size && j < rowSize)
        {
            if (pawns[i] != null)
            {
                shooters[i] = true;
                pawns[i].canFire = true;
                i = (i % rowSize) + 1;
                j++;
            }
            else if (i >= size - rowSize)
            {
                i = (i % rowSize) + 1;
                j++;
            }
            else
                i += rowSize;
        }
     

    }
    void Fire()
    {
        canFire = false;
        System.Random rand = new System.Random();
        int index = rand.Next(size);
        while (!shooters[index])
        {
           index = rand.Next(size);
        }
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
        shooters[index] = false;
        game.UpdateEnemyLives();
        game.UpdateScore(pawns[index].tag.ToString());
        pawns[index] = null;
        if((size - alive)% rowSize== 0)
        {
            speed++;
        }
        if (alive < rowSize)
            speed++;
       
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
