using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public GameObject Group;
    public bool makeMove = false;
    public float xpos;
    public float speed = 1;

    private void Start()
    {
        foreach (Transform parent in Group.transform)
        {
            foreach(Transform child in parent.transform)
                child.gameObject.GetComponent<Enemy>().MoveLeft(speed);
        }
    }

    private void Update()
    {
        Listen();
        FindShooters();
    }
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
    void FindShooters()
    {
        int row = 0;
        foreach (Transform parent in Group.transform)
        {
            
            int col = 0;
            foreach (Transform child in parent.transform)
            {
                if (child.gameObject.GetComponent<Enemy>().canShoot)
                    print(row +": " + col);
                col++;
             }
            row++;
        }
    }
    void Fire()
    {
    

    }
}
