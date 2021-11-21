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

    float score = 0;

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
        if (collision.gameObject.tag == tagEnemy && collision.transform.localScale.x > player.transform.localScale.x)
        {
            if (playerRb != null)
            {
                
            }
            Debug.Log("You Died");
            gameOver = true;
        }
    }

    private void Update()
    {
        if (score >= 200000 && !levelWon)
        {
            levelWon = true;
            levelWonText.gameObject.SetActive(true);
            Debug.Log("Level won");
        }
        if (gameOver)
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}
