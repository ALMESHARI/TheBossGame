using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public LogicScript logic;

    public GameObject[] obstaclPrefab;

    public float spownTime = 1f;

    private float timer = 0;


void start(){
logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
            logic.hello();
}
    // Update is called once per frame
    void Update()
    {
        if(logic.getIsGameOver() == false){
        if (timer > spownTime)
        {
            int rand = Random.Range(0, obstaclPrefab.Length);
            GameObject obs = Instantiate(obstaclPrefab[rand]);
            

            obs.transform.position = transform.position + new Vector3(0, 0, 0);
            timer = 0;
            spownTime = Random.Range(3f, 5f);
        }
        timer += Time.deltaTime;
        }
    }

  
}
