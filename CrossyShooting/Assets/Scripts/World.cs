using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class World : MonoBehaviour
{
    [SerializeField] GameObject land;
    GameObject[] lands;
    Vector3 spawnPoint;
  

    public int SIZE = 3;

    private void Awake()
    {
        
        
        GenerateWorld();

    }
    void SpawnLand(int i)
    {
        lands[i] = Instantiate(land, spawnPoint, Quaternion.identity);
        lands[i].transform.parent = gameObject.transform;
        lands[i].GetComponentInChildren<Trigger>().LandTriggerEvent.AddListener(delegate { RemoveLand(i); });
        spawnPoint += new Vector3(0, 0, land.transform.localScale.z);
    }
    void GenerateWorld()
    {
        lands = new GameObject[SIZE];
        spawnPoint = transform.position;

        for (int i = 0; i < SIZE; i++)
        {
            SpawnLand(i);
        }
    }
    void RemoveLand(int i)
    {
        lands[i].GetComponent<Land>().InfromMotherShip();
        Destroy(lands[i]);
        SpawnLand(i);
  
    }



}
/*
 Class World

    Data Members:

        GameObject land 
        GameObject[] lands
        Vector3 spawnPoint

        UnityEvent DestroyEvent;//informs land about destruction
    
        int SIZE  // holds size of world aka number of lands

    Functions:

        SpawnLand(i)//instatiate land update spawn point add to lands[i]
        GenerateWorld()//initialize world with set size of lands //also listen for Trgger event
        RemoveLand(i)//Destroy i and add land
        
    
    */