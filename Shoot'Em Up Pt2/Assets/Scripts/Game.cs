using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public SceneLoad scene;
    [SerializeField] MotherShip mother;
    public TextMeshProUGUI SCORE;
    public TextMeshProUGUI HI_SCORE;
    public TextMeshProUGUI LIVES;
    //player properties
    int playerScore;
    int playerLives;
    int highScore;
    //mothership properties
    int enemiesAlive;
    int size = 25;
    int rowSize = 5;
    float speed = 1;

    private void Awake()
    {
        playerScore = 0;
        playerLives = 3;
        highScore = 0;
        
    }
    private void Start()
    {
        playerScore = 0;
        playerLives = 3;
        SCORE.text = "SCORE\n" + (playerScore.ToString()).PadLeft(4,'0');
        LIVES.text = playerLives.ToString();
        HI_SCORE.text ="HI-SCORE\n" +highScore.ToString().PadLeft(4,'0') ;
        StartCoroutine(Begin());
    }
    IEnumerator Begin()
    {

        yield return new WaitForSeconds(2f);
        mother.SpawnAndTag(size,rowSize,speed);
        enemiesAlive = size;

    }
    public void UpdateScore(string tag)
    {
        System.Random rand = new System.Random();
        int value = rand.Next(100);

        if (tag == "30PTS") playerScore += 30;
        if (tag == "20PTS") playerScore += 20;
        if (tag == "10PTS") playerScore += 10;
        if (tag == "?PTS")  playerScore += value;
        SCORE.text = "SCORE\n" + (playerScore.ToString()).PadLeft(4,'0');
    }
    public void UpdatePlayerLives()
    {
        playerLives--;
        LIVES.text = playerLives.ToString();
        if (playerLives == 0)
        {
            mother.DestroyAll();
            if (playerScore > highScore) highScore = playerScore;
                 HI_SCORE.text = "HI-SCORE\n" + (highScore.ToString().PadLeft(4, '0'));
            scene.Next();
        }
           
    }
    public void UpdateEnemyLives()
    {
        enemiesAlive--;
        print(enemiesAlive);
        if (enemiesAlive == 0)
        {
            Start();
        }
    }


}
