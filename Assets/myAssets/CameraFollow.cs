using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if (RedCoinEffect.isColliding)
        {
            transform.position = player.transform.position + new Vector3(0, 6, -10);
        }
        else
        {
            
            transform.position = player.transform.position + new Vector3(0, 3, -5);
        }
    }
}