using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float lifespan = 3f; // Time in seconds before the coin disappears
    private GameManager gameManager; // Reference to the GameManager

    private void Start()
    {
        // Find the GameManager in the scene if not assigned
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Destroy the coin after a set lifespan if not picked up
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with the coin
        if (other.CompareTag("Player"))
        {
            // Add score and destroy the coin
            if (gameManager != null)
            {
                gameManager.EarnScore(1);
            }
            Destroy(gameObject);
        }
    }
}
