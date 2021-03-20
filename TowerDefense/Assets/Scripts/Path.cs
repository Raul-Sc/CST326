using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private WayPoint[] points;
    // Start is called before the first frame update
    private void Awake()
    {
      points = gameObject.GetComponentsInChildren<WayPoint>();
    }
    public WayPoint[] GetPoints()
    {
        return points;
    }
}
/*
class Path
    Functions:
       Awake()//Obtain all way points
       GetPoints()//returns points array
     Data members:
        Transform[] points;//waypoints

*/