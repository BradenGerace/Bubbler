using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject targets;
    public GameObject player;

    private float spawnRate = 0.9f;

    public TextMeshProUGUI scoreText;
    private int score;

    public GameManager gameManager;

    [SerializeField]
    private float enemyMin = 0.5f;
    [SerializeField]
    private float enemyMax = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = GetComponent<GameManager>();

        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);


    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(spawnRate);

                float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, (Screen.height))).y);
                float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2((Screen.width), 0)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                
                float circleSize = Random.Range(enemyMin, enemyMax);

                Vector3 randomSize = new Vector3(circleSize, circleSize, 1);

                //set it to the scale of previously instantiated circle

                if (player.transform.localScale.x <= 6)
                {
                    targets.transform.localScale = randomSize * (player.transform.localScale.x / 2);

                }
                else
                {
                    targets.transform.localScale = randomSize * 3;

                }

                Instantiate(targets, spawnPosition, Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f))));

                if (spawnRate > 0.4f)
                {
                    spawnRate -= 0.001f;
                }
                
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = PlayerPrefs.GetString("name") + ": " + score;
    }
    
}
