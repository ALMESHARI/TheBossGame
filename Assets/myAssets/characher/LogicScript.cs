using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LogicScript : MonoBehaviour
{
    public static LogicScript instance; 
    public int score;
    public Text scoreText;
    public GameObject gamePanel;
    public GameObject LeadBoardPanel;
    public GameObject player;
    // public AudioClip GameSound;
    private bool isGameOver = true;
    public static float speed = 10f;
    public float speedIncreaseInterval = 5f;
    public float speedIncreaseAmount = 1f;
    private float speedIncreaseTimer =0f;
    public bool isFirstGame=true;
    public GameObject gameOverPanel;
    // public AudioSource audioSource;

    void Start() {
        // audioSource = GetComponent<AudioSource>();
       
    }



    public void addScore(){
        score++;
        scoreText.text = "Score: "+score.ToString();
    }


    public void restartGame(){
        score = 0;
        scoreText.text = "Score: "+score.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(){
        isGameOver = false;
        // play Game sound
       
        
        // AudioSource.PlayClipAtPoint(GameSound, transform.position);
        // audioSource.Play();

        
        player.SetActive(true);
        gamePanel.SetActive(false);

    }

    void Awake() {
        // if (instance == null){
            instance = this;
        // }
    }

    public void gameOver(){
        isGameOver = true;
        // ObstacleSpawner.isSpawning = false;
        player.SetActive(false);
        

        // stop Game sound
        // audioSource.Stop();

        // gamePanel.SetActive(true);
        gameOverPanel.SetActive(true);

        // restartGame();
    }

    public void showLeaderBoard(){
        gamePanel.SetActive(false);
        LeadBoardPanel.SetActive(true);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //hide leaderboard and show game panel
    public void hideLeaderBoard(){
        gamePanel.SetActive(true);
        LeadBoardPanel.SetActive(false);
    }

    public bool getIsGameOver(){
        return isGameOver;
    }

    public float getSpeed(){
        return speed;
    }

    public void setSpeed(int newSpeed){
        speed = newSpeed;
    }

    void FixedUpdate(){
        // Update the timer
        // speedIncreaseTimer += Time.fixedDeltaTime;

        // // Check if it's time to increase the speed
        // if (speedIncreaseTimer >= speedIncreaseInterval)
        // {
        //     speed += speedIncreaseAmount;
        //     speedIncreaseTimer = 0f;
        // }
    }

    public void hello(){
        Debug.Log("Hello");
    }

}
