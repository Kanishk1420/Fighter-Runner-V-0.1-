using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    public ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
            scoreManager.IncreaseScore(); // Add this line
        }
        else if (collision.tag == "Player")
        {
            // scoreManager.DecreaseScore(); // Comment out or remove this line
        }
    }
}
