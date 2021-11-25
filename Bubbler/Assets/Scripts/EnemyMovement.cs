using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float minSpeed = -6.0f;
    [SerializeField]
    private float maxSpeed = 6.0f;

    [SerializeField]
    private Rigidbody2D enemyRb;

    public Collider2D enemyCollider;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb.velocity = RandomVector(minSpeed, maxSpeed);
        StartCoroutine(ActiveRb(0.5f + (enemy.transform.localScale.x / 20)));
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    IEnumerator ActiveRb(float time)
    {
        enemyCollider.enabled = false;
        yield return new WaitForSeconds(time);
        enemyCollider.enabled = true;
    }
}
