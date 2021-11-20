using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public string tagEnemy;
    public float increase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagEnemy)
        {
            transform.localScale += collision.gameObject.transform.localScale / 10;
            Destroy(collision.gameObject);
        }
    }
}
