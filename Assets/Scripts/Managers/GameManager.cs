using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameWon;
    ProfileManager profileManager;

    private void OnEnable()
    {
        Enemy.OnDefeat += WinGame;
        Player.OnDefeat += LoseGame;
    }

    private void Start()
    {
        profileManager = FindObjectOfType<ProfileManager>();
    }

    public void WinGame()
    {
        gameWon = true;
    }
    public void LoseGame()
    {
        gameWon = false;
    }
}
