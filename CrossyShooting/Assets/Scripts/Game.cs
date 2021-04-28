using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    Canvas gui;
    World world;
    Player player;
    Text rounds;
    void Awake()
    {
        player = GetComponentInChildren<Player>();
        world = GetComponentInChildren<World>();
        gui = GetComponentInChildren<Canvas>();
        rounds = gui.transform.Find("Rounds").GetComponent<Text>();
    }
    private void FixedUpdate()
    {
        rounds.text = player.GetComponentInChildren<Gun>().magSize.ToString() + " / - ";
    }

}
