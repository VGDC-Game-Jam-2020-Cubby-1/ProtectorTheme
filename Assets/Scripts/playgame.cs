﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playgame : MonoBehaviour
{
    public void PlayGame()
    {
    SceneManager.LoadScene(1);
    }
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void credits()
    {
    SceneManager.LoadScene(2);
    }

}

