using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Diagnostics;

public class SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject streetPrefab;
    public float spawnRate = 20f;
    private float timer = 0f;
    // public LogicScript logic;

    //public float heightOffset = 8f;
    // Start is called before the first frame update
    void Start()
    {
            //    logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();

    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if ((timer += Time.deltaTime) >= spawnRate){
            SpawnStreet();
            timer = 0;
        }
    }
 
    void SpawnStreet(){
        Instantiate(streetPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation);
        //Debug.Log("Spawned");
    }
}
