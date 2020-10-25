using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int mainMenuScene = 0;
    public int gameScene = 1;

    public float score = 0f;
    public bool isPaused = false;

    private GameObject[] chefs;

    bool gameOver = false;

    private TextMeshProUGUI scoreUI;
    private GameObject pauseUI;
    private GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        Debug.Log(scoreUI);
        
        scoreUI.text = "Testing..";

        pauseUI = GameObject.FindGameObjectWithTag("PauseUI");
        pauseUI.SetActive(false);
        gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        gameOverUI.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime*5;
        scoreUI.text = "" + (int) score;

        chefs = GameObject.FindGameObjectsWithTag("Chef");
        if(chefs.Length <=0 && !gameOver){
            gameOver = EndGame();
        }

    }

    public bool EndGame()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(mainMenuScene);
        return true;
    }

    public void ExitGame(){
        Debug.Log("Exit Game");
        SceneManager.LoadScene(mainMenuScene);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void PauseGame()
    {
        if(!isPaused){
            Time.timeScale = 0;
            pauseUI.SetActive(true);
            isPaused = true;
        } else if(isPaused){
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            isPaused = false;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        
    }
}
