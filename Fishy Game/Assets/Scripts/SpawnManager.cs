using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject targets;

    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI gameOverText;

    public bool isGameActive;

    public Button restartButton;

    // Start is called before the first frame update
    private void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    private void Update()
    {
        
    }



    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(spawnRate);

                float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                Instantiate(targets, spawnPosition, Quaternion.identity);
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
