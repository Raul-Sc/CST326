using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    Canvas gui;
    World world;
    Player player;
    Text rounds, score, gameOver;
    void Awake()
    {
        player = GetComponentInChildren<Player>();
        world = GetComponentInChildren<World>();
        gui = GetComponentInChildren<Canvas>();
        rounds = gui.transform.Find("Rounds").GetComponent<Text>();
        score = gui.transform.Find("Score").GetComponent<Text>();
        gameOver = gui.transform.Find("GameOver").GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        rounds.text = player.GetComponentInChildren<Gun>().magSize.ToString() + " / - ";
        score.text = player.score.ToString();
    }
    public void  Restart()
    {
        gameOver.enabled = true;
        StartCoroutine(LoadIntro());
    }
    IEnumerator LoadIntro()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Intro");

    }
    
}
