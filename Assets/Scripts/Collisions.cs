using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public Ball currentBall;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(" hit " + this.name);
    }
}
