using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score = 0f;

    private GameObject[] chefs;

    private TextMeshProUGUI scoreUI;
    private GameObject pauseUI;
    private GameObject gameOverUI;
    private GameObject pauseButton;

    void Awake()
    {
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        pauseUI = GameObject.FindGameObjectWithTag("PauseUI");
        gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
        pauseButton = GameObject.FindGameObjectWithTag("PauseButton");
    }

    void Start()
    {
        Debug.Log(scoreUI);

        scoreUI.text = "Testing..";

        gameOverUI.SetActive(false);
        IsPaused = false;
    }

    void Update()
    {
        score += Time.deltaTime * 5;
        scoreUI.text = "" + (int)score;

        chefs = GameObject.FindGameObjectsWithTag("Chef");
        if (chefs.Length <= 0 && !gameOverUI.activeInHierarchy)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused || gameOverUI.activeInHierarchy)
            {
                MainMenu.Menu();
            }
            else
            {
                IsPaused = true;
            }
        }
    }

    private bool _IsPaused;

    public bool IsPaused
    {
        get
        {
            return _IsPaused;
        }
        set
        {
            Time.timeScale = value ? 0 : 1;
            pauseUI.SetActive(value);
            pauseButton.SetActive(!value);

            _IsPaused = value;
        }
    }
}
