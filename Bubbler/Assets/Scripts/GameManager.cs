using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private EnemyPoints enemyPointsScript;
    public GameObject enemyPrefab;

    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;

    public bool isGameActive;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        enemyPointsScript = GetComponent<EnemyPoints>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isGameActive)
            {
                RestartGame();
            }
        }
    }



    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        isGameActive = false;
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
