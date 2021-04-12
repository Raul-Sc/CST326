using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] Basetower myTower;
    MazeBuilder maze;
    EnemyManager motherShip;
    FitMaze cam;
    Player player;
    [SerializeField] Text wave;
 
    public struct Wave
    {
        public int seekers;
        public int smart;
        public Wave(int se,int sm)
        {
            seekers = se;
            smart = sm;
        }
    }
    List<Wave> level;
    int levelIndex = 0;
    readonly int waveAmount = 10;

    public int sizeOfMaze = 3;
    public bool loadNextLevel = false;

    // Start is called before the first frame update
    private void Awake()
    {

        level = new List<Wave>();
        SetWaves();
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
            StartCoroutine(SpawnWave());
        }
        GameObject Player = GameObject.Find("Player");
        if (Player != null)
        {
            player = Player.GetComponent<Player>();
            player.purse = 100;
        }
    }
    void SetWaves()
    {

        int enemySeekers = 25;
        int enemySmart = 0;

        for(int i = 0; i < waveAmount; i++)
        {
            Wave wave = new Wave(enemySeekers, enemySmart);
            level.Add(wave);

            enemySeekers -= 2;
            enemySmart += 3;
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
        if (motherShip.spawnNewWave)
        {
            motherShip.alive = -1;
            motherShip.spawnNewWave = false;
            if (levelIndex < waveAmount)
            {
                levelIndex++;
                StartCoroutine(SpawnWave());
            }
        }
        if (myTower.health <= 0)
        {
           
            SceneManager.LoadScene("Lost");
        }
        if (levelIndex +1 == waveAmount && motherShip.alive == 0 && myTower.health > 0)
            SceneManager.LoadScene("DemoOver");
      
    }
    IEnumerator SpawnWave()
    {
        wave.text = "Wave: " + (levelIndex + 1) + "/ 10";
        yield return new WaitForSeconds(3);
        motherShip.Spawn(maze,level[levelIndex].seekers,level[levelIndex].smart,levelIndex);
    }
}
