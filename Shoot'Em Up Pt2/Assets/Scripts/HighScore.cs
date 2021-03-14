using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI HI_SCORE;

    private void Start()
    {
        HI_SCORE.text = "HI-SCORE\n" + PlayerPrefs.GetInt("HighScore", 0).ToString().PadLeft(4, '0');

    }
}
