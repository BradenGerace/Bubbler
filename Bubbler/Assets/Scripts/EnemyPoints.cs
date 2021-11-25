using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour
{
    public float pointValue;

    // Start is called before the first frame update
    void Start()
    {
        pointValue = Mathf.Round(transform.localScale.x * 100);
    }

}
