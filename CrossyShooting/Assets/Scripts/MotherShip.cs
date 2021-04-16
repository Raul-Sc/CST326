using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    List<Enemy> pawns;
    private void Awake()
    {
        pawns = new List<Enemy>();
    }
    void Spawn()
    {
       
        GameObject temp =  Instantiate(enemy, transform.position, Quaternion.identity);
        pawns.Add(temp.GetComponent<Enemy>());

    
    }
    private void Start()
    {
        Spawn();
        pawns[0].Shoot();
    }
}
/*
 class MotherShip
    DataMembers:
        GameObject enemy;

        List<Enemy> pawns;

     Functions:
        Spawn() 

*/