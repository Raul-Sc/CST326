using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        if (!gameObject.CompareTag("Shredder") ) 
        {
            Destroy(gameObject);
        }
    }
}
