using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitMaze : MonoBehaviour
{
    public void PositionToMaze(int sizeOfMaze, Transform parent)
    {
        transform.position = new Vector3(sizeOfMaze, parent.transform.position.y - sizeOfMaze+1, -1);
        transform.GetComponent<Camera>().orthographicSize = sizeOfMaze +1;
    }

}
