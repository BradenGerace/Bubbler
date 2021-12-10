using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManuUI : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    public static float highscore;

    public TMP_InputField playernameInput;
    public int characterLimit;

    public string defaultName = "Guest";

    // Start is called before the first frame update
    void Start()
    {
        //highscoreText = GetComponent<TextMeshProUGUI>();
        //highscore = GetComponent<float>();

        highscore = 0;

        // highscore = PlayerPrefs.GetFloat("highscore", highscore);
        int intHighscore = Mathf.RoundToInt(PlayerPrefs.GetFloat("highscore", 0));


        highscoreText.text = "Highscore: " + PlayerPrefs.GetString("highscorename") + " - " + intHighscore.ToString();

        playernameInput.characterLimit = 10;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void savePlayerName ()
    {
        

        if (string.IsNullOrEmpty(playernameInput.text))
        {
            playernameInput.text = defaultName;
            PlayerPrefs.SetString("name", playernameInput.text);
            Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        }
        else
        {
            PlayerPrefs.SetString("name", playernameInput.text);
            Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        }
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
