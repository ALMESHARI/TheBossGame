using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsSpawner : MonoBehaviour
{
    public GameObject[] obstaclPrefab;
    public LogicScript logic;

    public float spownTime = 1f;

    private float timer = 0;
void start(){
logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
            logic.hello();
}
    // Update is called once per frame
    void Update()
    {
        if (logic.getIsGameOver() == false){
        if (timer > spownTime)
        {
            int rand = Random.Range(0, obstaclPrefab.Length);
            GameObject obs = Instantiate(obstaclPrefab[rand]);
            if (gameObject.tag == "diagnoal")
            {
                obs.transform.position += new Vector3(12.73f, 0, 40f);
            }
            else
            {
                obs.transform.position += new Vector3(Random.Range(-2.25f, 2.25f), 0, 40f);
            }



            // randowm vector3 position for the coins in x between -1.65 and 6.5

            timer = 0;
            spownTime = Random.Range(2f, 3f);
        }
        timer += Time.deltaTime;
    }}
}
