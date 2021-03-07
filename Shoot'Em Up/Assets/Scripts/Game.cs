using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] MotherShip mother;
    public TextMeshProUGUI SCORE;
    public TextMeshProUGUI HI_SCORE;
    public TextMeshProUGUI LIVES;

    int playerScore;
    public int playerLives;
    int highScore;
    

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
        mother.SpawnAndAssign();


    }
    public void UpdateScore(string tag)
    {
        if (tag == "30PTS") playerScore += 30;
        if (tag == "20PTS") playerScore += 20;
        if (tag == "10PTS") playerScore += 10;
        SCORE.text = "SCORE\n" + (playerScore.ToString()).PadLeft(4,'0');
    }
    public void UpdateLives()
    {
        playerLives--;
        LIVES.text = playerLives.ToString();
        if (playerLives == 0)
        {
            mother.DestroyAll();
            if (playerScore > highScore) highScore = playerScore;
                 HI_SCORE.text = "HI-SCORE\n" + (highScore.ToString().PadLeft(4, '0'));
            Start();
        }
    }


}
