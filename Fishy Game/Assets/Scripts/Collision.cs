using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
                Destroy(playerRb);
            }
            Debug.Log("You Died");
            gameOver = true;
        }
    }

    private void Update()
    {
        if (score >= 100000 && !levelWon)
        {
            levelWon = true;
        }
        if (gameOver)
        {

        }
    }
}
