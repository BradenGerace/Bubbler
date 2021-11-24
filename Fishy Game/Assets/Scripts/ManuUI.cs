using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManuUI : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    public float highscore;

    // Start is called before the first frame update
    void Start()
    {
        //highscoreText = GetComponent<TextMeshProUGUI>();
        //highscore = GetComponent<float>();

        highscore = 0;

        // highscore = PlayerPrefs.GetFloat("highscore", highscore);
        int intHighscore = Mathf.RoundToInt(PlayerPrefs.GetFloat("highscore", 0));

        highscoreText.text = "Highscore: " + intHighscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
