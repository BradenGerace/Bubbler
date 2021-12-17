using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject pausedPanel;
    public GameObject unpauseButton;

    // Start is called before the first frame update
    void Start()
    {
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!gameIsPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
        
    }

    public void Pause()
    {
        pausedPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
        unpauseButton.gameObject.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        pausedPanel.gameObject.SetActive(false);
        unpauseButton.gameObject.SetActive(false);
    }
}
