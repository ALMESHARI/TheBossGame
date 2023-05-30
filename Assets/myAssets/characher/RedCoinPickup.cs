using UnityEngine;

public class RedCoinPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedCoin"))
        {
            // Disable collision with the RedCoin object
            Physics.IgnoreCollision(other, GetComponent<Collider>(), true);
            // Set a timer for how long the player should be invincible
            Invoke("EnableCollision", 5f);
        }
    }

    void EnableCollision()
    {
        // Re-enable collision with all objects
        Physics.IgnoreLayerCollision(0, 0, false);


    }
}
