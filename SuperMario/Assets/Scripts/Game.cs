using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] TextMeshProUGUI Coins;
    [SerializeField] TextMeshProUGUI Time;
    public GameObject stone;


    int playerScore = 0;
    int playerCoins = 0;
    int initialTime = 400;
    DateTime time1;
    TimeSpan interval;
    private void Start()
    {
        Score.text = "MARIO\n" + playerScore.ToString().PadLeft(6, '0');
        Coins.text = "x" + playerCoins.ToString().PadLeft(2, '0');
        time1 = DateTime.Now;

    }
    void Update()
    {
        //timer
        DateTime time2 = DateTime.Now;
        interval = time2 - time1;
        int time = initialTime - interval.Seconds;
        //GUI
        Time.text = "TIME\n" + time.ToString().PadLeft(3, '0');
        Coins.text = "x" + playerCoins.ToString().PadLeft(2, '0');
        Score.text = "MARIO\n" + playerScore.ToString().PadLeft(6, '0');

        //detect what the mouse clicks on
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name == "Question(Clone)")
                {
                    playerCoins++;
                    playerScore += 200;

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

}
