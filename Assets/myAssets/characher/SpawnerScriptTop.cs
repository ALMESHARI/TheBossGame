
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Diagnostics;

public class SpawnerScriptTop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TopStreetPrefab;
    private float timer = 0f;
    public float spawnRate = 5f;
    //public float heightOffset = 8f;
    // Start is called before the first frame update
    void Start()
    {
       
    }
 
    // Update is called once per frame
    void Update()
    {
        if ((timer += Time.deltaTime) >= spawnRate){
            SpawnStreet();
            
            timer = 0;
        }
    }
 
    void SpawnStreet(){
        Instantiate(TopStreetPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);//transform.rotation + new vector3(0,0,180));
    }
}
