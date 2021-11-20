using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private EnemyPoints enemyPointsScript;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        enemyPointsScript = GetComponent<EnemyPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
