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

    public static float score;
    public static float highscore;
    public static bool isHighscore;

    bool levelWon;
    public TextMeshProUGUI levelWonText;

    bool gameOver;
    public GameObject gameOverPanel;

    public SpriteRenderer playerSprite;

    private void Start()
    {
        gameOver = false;
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagEnemy && collision.transform.localScale.x <= player.transform.localScale.x)
        {
            transform.localScale += collision.gameObject.transform.localScale / 50;
            Destroy(collision.gameObject);

            score += collision.transform.localScale.x * 100;

            if (score >= 99999)
            {
                score = 99999;
            }

            scoreText.text = "Score: " + Mathf.RoundToInt(score);

            if (score > PlayerPrefs.GetFloat("highscore", 0))
            {
                
                isHighscore = true;

                PlayerPrefs.SetFloat("highscore", score);
            }

        }
        if (collision.gameObject.tag == tagEnemy && collision.transform.localScale.x > player.transform.localScale.x && !gameOver)
        {
            GameOver();
            
        }
    }

    

    private void Update()
    {
        if (score >= 99999 && !levelWon)
        {
            LevelWon();
        }
        
       
    }

    public void GameOver ()
    {
        Debug.Log("You Died");
        playerSprite.enabled = false;
        player.GetComponent<Collider2D>().enabled = false;
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    public void LevelWon ()
    {
        levelWon = true;
        levelWonText.gameObject.SetActive(true);
        Debug.Log("Level won");
    }
}
