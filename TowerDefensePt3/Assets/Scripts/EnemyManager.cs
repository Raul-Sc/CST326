using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    int seek = 0;
    int smart = 0;
    int size = 1;
    public int alive = -1;
    List<Enemy> pawns;
   
    public GameObject enemy;
    public bool spawnNewWave = false;
    // Start is called before the first frame update
  

    // Update is called once per frame
    public void Spawn(MazeBuilder maze, int newSeek,int newSmart, int wave)
    {

        size = newSeek + newSmart;
        alive = size;
        seek = newSeek;
        smart = newSmart;
        pawns = new List<Enemy>();
      
        StartCoroutine(SpawnSpacedOut(maze,wave));
    
    }
    IEnumerator SpawnSpacedOut(MazeBuilder maze,int wave)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject temp = Instantiate(enemy, transform.position, Quaternion.identity);
         
            pawns.Add(temp.GetComponent<Enemy>());
            pawns[i].DeathEvent.AddListener(delegate { RemovePawn(); });
            pawns[i].myPath = maze.seekPath;
            pawns[i].speed += wave/10;
            if( i >= seek)
            {
                Renderer pawnColor = pawns[i].GetComponent<Renderer>();
                pawnColor.material.SetColor("_Color", Color.blue);
                pawns[i].myPath = maze.bfsPath;
                pawns[i].damageMult = .40f;
                pawns[i].bounty = 7;
            }
            pawns[i].MoveToSpawn();
            yield return new WaitForSeconds(2 - (wave/10));
        }

    }
    void RemovePawn()
    {
        alive--;
    }
    private void Update()
    {
  
        if (alive == 0)
            spawnNewWave = true;
            
    }

    
}
