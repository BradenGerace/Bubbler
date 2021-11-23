using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public string tagEnemy;
    public TextMeshProUGUI scoreText;
    public float increase;

    public GameObject enemy;
    public GameObject player;

    public Rigidbody2D playerRb;

    public static float score = 0;
    public static float highscore;
    public static bool isHighscore;

    bool levelWon;
    public TextMeshProUGUI levelWonText;

    bool gameOver;
    public GameObject gameOverPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagEnemy && collision.transform.localScale.x <= player.transform.localScale.x)
        {
            transform.localScale += collision.gameObject.transform.localScale / 50;
            Destroy(collision.gameObject);

            score += collision.transform.localScale.x * 100;
            scoreText.text = "Score: " + Mathf.RoundToInt(score);
        }
        if (collision.gameObject.tag == tagEnemy && collision.transform.localScale.x > player.transform.localScale.x && !gameOver)
        {
            GameOver();
            
        }
    }

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (score >= 200000 && !levelWon)
        {
            LevelWon();
        }
        if (score > highscore)
        {
            highscore = score;
            isHighscore = true;

            PlayerPrefs.SetFloat("highscore", highscore);
        }
       
    }

    public void GameOver ()
    {
        Debug.Log("You Died");
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LevelWon ()
    {
        levelWon = true;
        levelWonText.gameObject.SetActive(true);
        Debug.Log("Level won");
    }
}
