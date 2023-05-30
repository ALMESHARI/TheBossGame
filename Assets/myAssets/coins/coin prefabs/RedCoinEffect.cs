using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCoinEffect : MonoBehaviour
{
    public float sizeMultiplier = 3.0f; // The size multiplier to apply to the player when it collides with this object
    public float duration = 3.0f; // The duration of the power-up effect in seconds

    public static bool isColliding = false; // Whether the player is currently colliding with the RedCoin object
    private GameObject player; // Reference to the player GameObject
    private Vector3 originalPlayerSize; // The original size of the player GameObject

    void Start()
    {
        // Get a reference to the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");

        // Save the original size of the player GameObject
        originalPlayerSize = player.transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Double the size of the player GameObject
            player.transform.localScale *= sizeMultiplier;

            // Set isColliding to true so that the update function knows to start the timer
            isColliding = true;

            // Start the timer
            StartCoroutine(ResetSizeAfterDelay());
        }
    }

    void FixedUpdate()
    {
        // If the player is currently colliding with the RedCoin object, update the timer
        if (isColliding)
        {
            // Count down the timer
            duration -= Time.deltaTime;

            // If the timer has reached 0, reset the size of the player GameObject
            if (duration <= 0)
            {
                player.transform.localScale = new Vector3(1,1,1);

                // Reset the duration and isColliding flag
                duration = 3.0f;
                isColliding = false;
            }
        }
        if (!isColliding && player.transform.localScale != new Vector3(1,1,1))
        {
            player.transform.localScale = new Vector3(1,1,1);
            
        }

        

    }

    IEnumerator ResetSizeAfterDelay()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the size of the player GameObject
        player.transform.localScale = originalPlayerSize;

        // Reset the duration and isColliding flag
        duration = 3.0f;
        isColliding = false;
        player.transform.localScale = originalPlayerSize;


    }
}
