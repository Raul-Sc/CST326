using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public Ball ball;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
            if (this.name == "Mid")
                Debug.Log("HIT");


    }
}
