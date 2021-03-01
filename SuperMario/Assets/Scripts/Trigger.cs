using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Player p;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "finish(Clone)")
        {
            p.gameOver = true;
            Debug.Log("You Won");
        }

    }
    
}
