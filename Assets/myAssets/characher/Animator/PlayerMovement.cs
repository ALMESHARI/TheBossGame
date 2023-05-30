using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpHeight = 2f; // The height the player jumps when the W key is pressed
    private float sizeMultiplier = 2f; // The multiplier used to increase/decrease the size of the collider

    private BoxCollider boxCollider;
    private bool isCooldown = false; // Indicates if a cooldown is active
    private KeyCode lastKey = KeyCode.None; // The last key that was pressed

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Check if a cooldown is active and return if true
        if (isCooldown) {
            return;
        }

        // Check if the W key is pressed and move the player up
        if (Input.GetKeyDown(KeyCode.W) && lastKey != KeyCode.W)
        {
            // Double the height of the collider
            boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y * sizeMultiplier, boxCollider.size.z);
            // Move the center of the collider up by half the new height
            boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y + boxCollider.size.y / 2f, boxCollider.center.z);

            // Start the cooldown
            isCooldown = true;
            lastKey = KeyCode.W;
            Invoke("ResetCollider", 1f);
        }

        // Check if the S key is pressed and reduce the height of the collider
        if (Input.GetKeyDown(KeyCode.S) && lastKey != KeyCode.S)
        {
            // Halve the height of the collider
            boxCollider.size = new Vector3(boxCollider.size.x, 0.3f, boxCollider.size.z);
            // Move the center of the collider down by half the old height
            boxCollider.center = new Vector3(boxCollider.center.x, 0, boxCollider.center.z);

            // Start the cooldown
            isCooldown = true;
            lastKey = KeyCode.S;
            Invoke("ResetCollider", 1f);
        }
    }

    void ResetCollider()
    {
        // Reset the collider to its original size and position
        boxCollider.size = new Vector3(boxCollider.size.x, jumpHeight, boxCollider.size.z);
        boxCollider.center = new Vector3(boxCollider.center.x, 0.8564065f, boxCollider.center.z);

        // End the cooldown
        isCooldown = false;
        lastKey = KeyCode.None;
    }
}
