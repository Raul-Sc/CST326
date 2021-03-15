using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.IO;
public class Game : MonoBehaviour
{
    public SceneLoad scene;
    public GameObject shieldPre;
    GameObject shields;
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
    public float speed = 2;

    private void Awake()
    {
        playerScore = 0;
        playerLives = 3;
        highScore = PlayerPrefs.GetInt("HighScore",0);
    }
    private void Start()
    {
        speed = 2;
        shields = Instantiate(shieldPre, transform.position, Quaternion.identity);
        playerScore = 0;
        playerLives = 3;
        SCORE.text = "SCORE\n" + (playerScore.ToString()).PadLeft(4,'0');
        LIVES.text = playerLives.ToString();
        HI_SCORE.text ="HI-SCORE\n" +highScore.ToString().PadLeft(4,'0') ;
        StartCoroutine(Begin());
    }
    IEnumerator Begin()
    {

        yield return new WaitForSeconds(1f);
        mother.SpawnAndTag(size, rowSize);
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
        //roll credits + update highscore
        if (playerLives == 0)
        {
            mother.DestroyAll();
            Destroy(shields);
            if (playerScore > highScore)
                PlayerPrefs.SetInt("HighScore", playerScore);
            scene.Next();
        }
           
    }
    public void UpdateEnemyLives()
    {
       
        enemiesAlive--;
        if (enemiesAlive == 0)
        {
            //respawn enemies a bit faster
            speed *=1.5f;
            mother.DestroyAll();
            StartCoroutine(Begin());
        }
    }


}
