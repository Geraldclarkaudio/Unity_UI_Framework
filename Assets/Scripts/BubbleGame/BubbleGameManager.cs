using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGameManager : MonoBehaviour
{
    public int _currentPopOrder;
    public bool _gameWon;

    private ProfileManager _profileManager;
    private GameManager _gameManager;
    public static Action onBubbleGameWin;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _profileManager = FindObjectOfType<ProfileManager>();   
        _currentPopOrder = 1;
        _gameWon = false;
    }

    public void IncrementPopOrder()
    {
        _currentPopOrder++;
        if(_currentPopOrder == 11){
            _gameWon=true;
            _gameManager.bubblesWon = true;
            _profileManager.WinBubbles();
            //go to results screen. 
            onBubbleGameWin?.Invoke();

        }
    }
}
