using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public TextMeshProUGUI pauseMenuHighscore;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuHighscore.text = "Highscore: \n" + PlayerPrefs.GetString("highscorename") + " - " + Mathf.RoundToInt(PlayerPrefs.GetFloat("highscore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
