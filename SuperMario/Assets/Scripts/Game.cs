using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] TextMeshProUGUI Timer;
    public GameObject stone;
    public Player player;
    public LevelParserStarter level;

    Vector3 initial_pos = new Vector3(9, 3, 0);
    int playerScore = 0;
    int playerCoins = 0;
    int initialTime = 100;
    int time;
    DateTime time1;
    private void Start()
    {
        player.gameOver = false;
        level.RefreshParse();
        player.transform.position = initial_pos;
        playerCoins = 0;
        playerScore = 0;
        Score.text = "MARIO\n" + playerScore.ToString().PadLeft(6, '0');
        Coins.text = "x" + playerCoins.ToString().PadLeft(2, '0');
        time1 = DateTime.Now;

    }
    bool GameOver()
    {
        if (time == 0)
            return true;
        else
            return player.gameOver;
    }
    void Update()
    {
        //restart
        if (GameOver())
        {
            Debug.Log("Game Over");
            Start();
        }
        //timer
        DateTime time2 = DateTime.Now;
        TimeSpan interval = time2 - time1;
        time = initialTime - interval.Seconds;
        //GUI
        Timer.text = "TIME\n" + time.ToString().PadLeft(3, '0');
        Coins.text = "x" + playerCoins.ToString().PadLeft(2, '0');
        Score.text = "MARIO\n" + playerScore.ToString().PadLeft(6, '0');
      
        //if player hit brick / question mark 
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position,Vector3.up, out hit,1.6f))
         { 
            print("Found an object - distance: " + hit.distance);
             print(hit.transform.gameObject.name);
             if (hit.transform.gameObject.name == "Question(Clone)")
             {
                 playerCoins++;
                 playerScore += 100;

                  GameObject ToSpawn = stone;
                  ToSpawn.transform.position = hit.transform.position;
                  Destroy(hit.transform.gameObject);
                  GameObject.Instantiate(ToSpawn);
                }
                else if (hit.transform.gameObject.name == "Brick(Clone)")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

    }

}
