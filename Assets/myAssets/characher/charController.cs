using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum SIDE
{
    Left,
    Mid,
    Right
}

public class charController : MonoBehaviour
{    
    public LogicScript logic;
    public SIDE m_side = SIDE.Mid;
    float NewXPos = 0f;
    private float leftWallX = -4.5f;
    private float rightWallX = 4.5f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float XValue;
    private CharacterController charControl;
    public bool isGameOver;
public float jumpHeight = 1.0f;
    public float jumpDuration = 1.0f;
private float jumpTimer = 0.0f;
private Vector3 startPosition;
    private int coinCount = 0;
    Text coinCountText;
    private Dictionary<string, int> coinInventory = new Dictionary<string, int>();



    public float movementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
         Rigidbody rb = GetComponent<Rigidbody>();
    // rb.centerOfMass = new Vector3(0, -0.5f, 0);
    //     charControl = GetComponent<CharacterController>();
        transform.position = new Vector3(0, -0.5f, 0);
        logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
        isGameOver = logic.getIsGameOver();
    }

    // Update is called once per frame
    void Update()
    {
        // isGameOver = logic.getIsGameOver();
        // if (isGameOver == false){
            gameObject.SetActive(true);
        jump();

        // Get the horizontal input axis value (left/right arrow or A/D keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the new position of the player based on the input
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, leftWallX, rightWallX);

        // Move the player to the new position
        transform.position = newPosition;

        //charControl.Move((horizontalInput * movementSpeed * Time.deltaTime - transform.position.x)*Vector3.right * Time.deltaTime);


        /*         SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
                SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

                if (SwipeLeft) {
                    if (m_side == SIDE.Mid) {
                        NewXPos = -XValue;
                        m_side = SIDE.Left;
                    }
                    else if (m_side == SIDE.Right) {
                        m_side = SIDE.Mid;
                        NewXPos = 0;
                    }
                } else if (SwipeRight) {
                    if (m_side == SIDE.Mid) {
                        NewXPos = XValue;
                        m_side = SIDE.Right;
                    }
                    else if (m_side == SIDE.Left) {
                        m_side = SIDE.Mid;
                        NewXPos = 0;
                    }
                }
                charControl.Move((NewXPos - transform.position.x) * Vector3.right * Time.deltaTime); */
    }

    public void AddCoins(string coinType, int amount)
    {
        if (coinInventory.ContainsKey(coinType))
        {
            coinInventory[coinType] += amount;
        }
        else
        {
            coinInventory.Add(coinType, amount);
        }

        coinCount += amount;
        // UpdateCoinCountText();
    }

    public void RemoveCoins(string coinType, int amount)
    {
        if (coinInventory.ContainsKey(coinType))
        {
            if (coinInventory[coinType] >= amount)
            {
                coinInventory[coinType] -= amount;
                coinCount -= amount;
                // UpdateCoinCountText();
            }
            else
            {
                Debug.LogWarning("Player does not have enough " + coinType + " coins.");
            }
        }
        else
        {
            Debug.LogWarning("Player does not have any " + coinType + " coins.");
        }
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstecle"){
            logic.gameOver();
            Debug.Log("Collision detected with " + other.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "obstecle" && !RedCoinEffect.isColliding){
            logic.gameOver();
            Debug.Log("Collision detected with " + other.gameObject.tag);
        }

        if (other.gameObject.tag == "GoldCoin" || other.gameObject.tag == "RedCoin"){
            logic.addScore();
            Debug.Log("Collision detected with " + other.gameObject.tag);
        }
    }

    void jump()
{
    Vector3 currentPosition = transform.position;

    if (Input.GetKeyDown(KeyCode.W))
    {
        jumpTimer = 0.0f;
    }

    jumpTimer += Time.deltaTime;

    if (jumpTimer < jumpDuration)
    {
        float jumpProgress = jumpTimer / jumpDuration;
        float yOffset = Mathf.Sin(jumpProgress * Mathf.PI) * jumpHeight;
        currentPosition.y = yOffset;
        transform.position = currentPosition;
    }
    else
    {
        currentPosition.y = -0.5f;;
        transform.position = currentPosition;
        jumpTimer = jumpDuration;
    }
}
}
