using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
public GameObject prefabToSpawn;
public float respawnTime = 20f;
    public LogicScript logic;

private bool gameStarted = false;
private float timeToRespawn;

void Start()
{
    // Start the game
    logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
    gameStarted = logic.getIsGameOver();
    // Set the initial time to respawn
    timeToRespawn = respawnTime;
}

void Update()
{
    if (!logic.getIsGameOver())
    {
        // Count down the time to respawn
        timeToRespawn -= Time.deltaTime;

        // Check if it's time to respawn
        if (timeToRespawn <= 0)
        {
            // Respawn the prefab
            Instantiate(prefabToSpawn, transform.position, transform.rotation);

            // Reset the time to respawn
            timeToRespawn = respawnTime;
        }
    }
}
}