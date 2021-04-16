using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
    private void Start()
    {
        Spawn();
    }
}
/*
 class MotherShip
    DataMembers:

        GameObject enemy
        Enemy[]
        Gun[]
        Movement[]

     Functions:
        Spawn() 

*/