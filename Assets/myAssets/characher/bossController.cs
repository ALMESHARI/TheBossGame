using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossController : MonoBehaviour
{
    Vector3 target;
    public float speed;
    private Vector3 moveDirection = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        setNewTarget(new Vector3(
            transform.position.x,
            transform.position.z,
            transform.position.y + 10
        ));
    }

    // move forward 10 units per second
    void Update()
    {

    }

    void setNewTarget(Vector3 newTarget)
    {
        target = newTarget;
        transform.LookAt(target);
    }
}
