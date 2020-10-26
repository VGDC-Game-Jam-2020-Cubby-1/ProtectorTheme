using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public const string PlayScene = "Latest";
    public const string MenuScene = "Performance";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    public static void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainMenu.PlayScene);
    }

    public static void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MainMenu.MenuScene);
    }

    public static void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
