using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Diagnostics;

public class MoveForwardCoin : MonoBehaviour
{
    public float deadZone;
    public float moveSpeed = 10f;    
    public float speedIncreaseInterval = 5f;
    public float speedIncreaseAmount = 1f;
    private float speedIncreaseTimer;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {         
        if (logic.getIsGameOver()){
            Destroy(gameObject);
        }
        if (transform.position.z < -deadZone){
            Destroy(gameObject);
        Debug.Log(transform.position.z);

        }
        transform.position += Vector3.back * moveSpeed * Time.deltaTime; 

        // Update the timer
        speedIncreaseTimer += Time.fixedDeltaTime;

        // Check if it's time to increase the speed
        if (speedIncreaseTimer >= speedIncreaseInterval)
        {
            moveSpeed += speedIncreaseAmount;
            speedIncreaseTimer = 0f;
        }
        
    }
}
