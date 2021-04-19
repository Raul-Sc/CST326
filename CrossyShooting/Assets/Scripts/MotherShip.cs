using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    List<Enemy> pawns;

    
    Quaternion SpawnRotation = Quaternion.Euler(0, 180, 0);

 
    private void Awake()
    {
        pawns = new List<Enemy>();
        GetComponentInChildren<Trigger>().TriggerEvent.AddListener(delegate { Spawn(); });
    }
    void Spawn()
    {
       
        GameObject temp =  Instantiate(enemy, transform.position, SpawnRotation);
        pawns.Add(temp.GetComponent<Enemy>());
        pawns[pawns.Count -1].DeathEvent.AddListener(delegate { PawnDown(pawns[pawns.Count-1]); });

    
    }
    public void DestroyPawns()
    {
        for (int i = 0; i < pawns.Count; i++)
            Destroy(pawns[i].gameObject);
        pawns.Clear();
    }
    void PawnDown(Enemy p)
    {
        pawns.Remove(p);
    }

}
/*
 class MotherShip
    DataMembers:
        GameObject enemy;

        List<Enemy> pawns;

        Quaternion SpawnRotation;

     Functions:
        Spawn();

*/