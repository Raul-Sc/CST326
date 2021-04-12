using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basetower : MonoBehaviour
{
    public int health = 100;
    private void OnTriggerEnter(Collider other)
    {
        health -= 10;

    }
    private void Update()
    {
        if (health == 0)
            transform.position = new Vector3(100, 0, 0);
            
    }
}
