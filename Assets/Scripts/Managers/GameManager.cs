using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameWon;
    public bool bubblesWon;
    private void OnEnable()
    {
        Enemy.OnDefeat += WinGame;
        Player.OnDefeat += LoseGame;
    }
    public void WinGame()
    {
        gameWon = true;
    }
    public void WinBubbleGame()
    {
        bubblesWon = true;
    }
    public void LoseGame()
    {
        gameWon = false;
    }
}
