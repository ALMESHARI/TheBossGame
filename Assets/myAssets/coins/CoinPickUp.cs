using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    // The amount of coins to add to the player's inventory when this coin is collected
    public int coinValue = 1;

    // The sound effect to play when this coin is collected
    public AudioClip pickupSound;

    // This function is called when a trigger collider enters this coin's collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Get a reference to the PlayerController script on the player object
            charController player = other.gameObject.GetComponent<charController>();


            // If the player controller script exists, add the coin value to the player's inventory
            if (player != null)
            {
                player.AddCoins(
                    gameObject.tag
                    , coinValue);
                Debug.Log(gameObject.tag + " coin collected");
                // Play the pickup sound effect
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

                // Destroy this coin object
                Destroy(gameObject);
            }
        }
    }

    // public static CoinPickUp instance;
    // void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
