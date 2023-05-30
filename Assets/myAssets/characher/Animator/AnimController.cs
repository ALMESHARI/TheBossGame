using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(animator != null){
            if (Input.GetKeyDown(KeyCode.S))
            {
            animator.SetTrigger("slide");
            Debug.Log("slide");
            }
            if(Input.GetKeyDown(KeyCode.W))
            {
            animator.SetTrigger("jump");
            Debug.Log("jump");
            }
       }   
    }
}
