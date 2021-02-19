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


    int playerScore = 5;
    int playerCoins = 5;
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
        DateTime time2 = DateTime.Now;
        interval = time2 - time1;
        int time = initialTime - interval.Seconds;
        Time.text = "TIME\n" + time.ToString().PadLeft(3, '0');


    }
}
