using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public GameObject row1;
    public bool makeMove = false;
    public float xpos;
    public float speed = 1;

    private void Start()
    {
        foreach (Transform child in row1.transform)
            child.gameObject.GetComponent<Enemy>().MoveLeft(speed);
    }

    private void Update()
    {
        Listen();
    }
    void Listen()
    {
        if (makeMove)
        {
            foreach (Transform child in row1.transform)
                child.gameObject.GetComponent<Enemy>().MoveDown();
            if (xpos < 0)
            {
                foreach (Transform child in row1.transform)
                    child.gameObject.GetComponent<Enemy>().MoveRight(speed);
            }
            else
            {
                foreach (Transform child in row1.transform)
                    child.gameObject.GetComponent<Enemy>().MoveLeft(speed);
            }
            makeMove = false;
        }

        

    }
}
