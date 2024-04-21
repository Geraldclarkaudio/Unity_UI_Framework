using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGameManager : MonoBehaviour
{
    public int _currentPopOrder;
    private bool _gameWon;

    private ProfileManager _profileManager;


    private void Start()
    {
        _profileManager = FindObjectOfType<ProfileManager>();   
        _currentPopOrder = 1;
        _gameWon = false;
    }

    public void IncrementPopOrder()
    {
        _currentPopOrder++;
        if(_currentPopOrder == 11){
            Debug.Log("You Win");
            _gameWon=true;
            _profileManager.WinBubbles();
        }
    }
}
