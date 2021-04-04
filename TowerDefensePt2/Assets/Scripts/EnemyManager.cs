using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    int size = 20;
    Enemy[] pawns;
    public GameObject enemy;
    // Start is called before the first frame update
  

    // Update is called once per frame
    public void Spawn(MazeBuilder maze)
    {
        pawns = new Enemy[size];
        StartCoroutine(SpawnSpacedOut(maze));
    
    }
    IEnumerator SpawnSpacedOut(MazeBuilder maze)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject temp = Instantiate(enemy, transform.position, Quaternion.identity);
            pawns[i] = temp.GetComponent<Enemy>();
            pawns[i].speed = 5;
            pawns[i].myPath = maze.seekPath;
            pawns[i].MoveToSpawn();
            yield return new WaitForSeconds(2);
        }

    }
}
