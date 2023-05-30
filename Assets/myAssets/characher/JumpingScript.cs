using UnityEngine;
public class JumpingScript : MonoBehaviour
{
    public float jumpHeight = 1.0f;
    public float jumpDuration = 1.0f;

//  

//     private float jumpTimer = 0.0f;
//     private Vector3 startPosition;

//  

//     void Start()
//     {
//         startPosition = transform.position;
//     }

//  

//     void Update()
//     {
//         jumpTimer += Time.deltaTime;

//  

//         if (jumpTimer)
//         {
//             float jumpProgress = jumpTimer / jumpDuration;
//             float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
//             transform.position = startPosition + new Vector3(0, yOffset, 0);
//         }
//         else
//         {
//             transform.position = startPosition;
//             jumpTimer = 0.0f;
//         }
//     }
// }

private float jumpTimer = 0.0f;
private Vector3 startPosition;

void Start()
{
    startPosition = transform.position;
}

void Update()
{
    if (Input.GetKeyDown(KeyCode.W))
    {
        jumpTimer = 0.0f;
    }

    jumpTimer += Time.deltaTime;

    if (jumpTimer < jumpDuration)
    {
        float jumpProgress = jumpTimer / jumpDuration;
        float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
        transform.position = startPosition + new Vector3(transform.position.x, yOffset, transform.position.z);
    }
    else
    {
        transform.position = startPosition;
        jumpTimer = jumpDuration;
    }
}
}