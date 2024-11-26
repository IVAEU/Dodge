using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Instance.curHealth.OnChanged += GameOver;
    }

    private void GameOver(int value)
    {
        if (value <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
