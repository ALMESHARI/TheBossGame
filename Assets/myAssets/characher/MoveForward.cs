// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// // using System.Diagnostics;

// public class MoveForward : MonoBehaviour
// {
//     public float deadZone = 300f;
//     public float moveSpeed = 10f;    
//     public float speedIncreaseInterval = 5f;
//     public float speedIncreaseAmount = 1f;
//     private float speedIncreaseTimer;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void FixedUpdate()
//     {
//         if (transform.position.z < -deadZone){
//             Destroy(gameObject);
//         Debug.Log(transform.position.z);

//         }
//         transform.position += Vector3.back * moveSpeed * Time.deltaTime; 

//         // Update the timer
//         speedIncreaseTimer += Time.fixedDeltaTime;

//         // Check if it's time to increase the speed
//         if (speedIncreaseTimer >= speedIncreaseInterval)
//         {
//             moveSpeed += speedIncreaseAmount;
//             speedIncreaseTimer = 0f;
//         }
        
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System;
// using System.Diagnostics;

public class MoveForward : MonoBehaviour
{
    public float deadZone= 300f;
    public float moveSpeed = 10f;
    public LogicScript logic;
    public bool isGameOver;
    public Time time;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
        isGameOver = logic.getIsGameOver();
        // time = DateTime.Now;
    }

    // Update is called once per frame
    void FixedUpdate(){

                isGameOver = logic.getIsGameOver();

    if (!isGameOver)
    {
        if (transform.position.z <= -deadZone){
            Destroy(gameObject);

        }
        transform.position += Vector3.back * moveSpeed * Time.deltaTime; 
        // Deubg.Log((DateTime.Now - time).ToString());
        // Debug.Log((Vector3.back * moveSpeed * Time.deltaTime).ToString());
    }
    }
}
