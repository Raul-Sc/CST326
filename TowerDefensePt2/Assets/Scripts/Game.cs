using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{ 
    MazeBuilder maze;
    EnemyManager motherShip;
    FitMaze cam;
    Player player;

    public int sizeOfMaze = 3;
    public bool loadNextLevel = false;
    // Start is called before the first frame update
    private void Awake()
    {
        cam = Camera.main.GetComponent<FitMaze>();
        GameObject mazeManager = GameObject.Find("MazeManager");
        if (mazeManager != null)
        {
            maze = mazeManager.GetComponent<MazeBuilder>();
            maze.BuildMazeAndPaths(sizeOfMaze);
        }
        if (cam != null)
            cam.PositionToMaze(sizeOfMaze, maze.transform);

        GameObject EnemyManager = GameObject.Find("EnemyManager");
        if( EnemyManager != null)
        {
            motherShip = EnemyManager.GetComponent<EnemyManager>();
            motherShip.Spawn(maze);
        }
        GameObject Player = GameObject.Find("Player");
        if (Player != null)
        {
            player = Player.GetComponent<Player>();
            player.purse = 100;
        }
    }
    void Play()
    {
        if (loadNextLevel)
        {
            loadNextLevel = false;
            maze.ClearWalls();
            sizeOfMaze += 2;
            maze.BuildMazeAndPaths(sizeOfMaze);
            cam.PositionToMaze(sizeOfMaze, maze.transform);

        }

    
    }

    // Update is called once per frame
    void Update()
    {
        Play();
    }
}
