using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameManager : MonoBehaviour
{
    [SerializeField]
    private Image _gameIcon; //the icon you have to drag the matching image to. 
    [SerializeField]
    private Image[] _answerIcons; // buttons below images
    [SerializeField]
    private List<Sprite> _matchableIcons; // list of icons to chose from
    [SerializeField]
    private int _spriteIndex; // index of the game icon
    [SerializeField]
    private Image _answerIcon; // the icon of the answer
    [SerializeField]
    private AnswerIcon _answer; // the AnswerIcon reference for the answer

    [SerializeField]
    private int _score;

    [SerializeField]
    private MatchingGameUI _gameUI;

    private ProfileManager _profileManager;

    private void OnEnable()
    {
        DraggableImage.onResetGame += StartGame;
        DraggableImage.onScored += AddScore;
    }
    private void OnDisable()
    {
        DraggableImage.onResetGame -= StartGame;
        DraggableImage.onScored -= AddScore;
    }

    private void Start()
    {
        _profileManager = FindObjectOfType<ProfileManager>();
        _score = _profileManager.profiles[_profileManager.selectedProfileIndex].level;
        _gameUI.UpdateScoreText(_score);
        StartGame();
    }

    private void StartGame()
    {
        //empty them before setting
        _gameIcon.sprite = null;

        for(int i =0; i < _answerIcons.Length; i++)
        {
            _answerIcons[i].sprite = null;
        }

        //set
        SetGameIcon();
        SetAnswerIcons();
    }
    private void SetGameIcon()
    {
        _spriteIndex = UnityEngine.Random.Range(0, _matchableIcons.Count); // makes a value
        _gameIcon.sprite = _matchableIcons[_spriteIndex]; // sets the game icon to that icon
    }
    private void SetAnswerIcons()
    {
        if (_answer != null)
        {
            _answer.answer = false;
        }
        //set one of the answers to the same as the gameIcon and set it's answer to true
        _answerIcon = _answerIcons[UnityEngine.Random.Range(0, _answerIcons.Length)]; // set the _answerIcon = to a random _answerIcon
        _answer = _answerIcon.GetComponentInParent<AnswerIcon>(); // get that answer's AnswerIcon class
        _answerIcon.sprite = _gameIcon.sprite; // set that sprite  = to game icon
        _answer.SetAnswer(); // make it true.

        //ensures the answer and center icons cant repeat by removing that sprite. 
        Sprite removedObject = _matchableIcons[_spriteIndex];
        _matchableIcons.Remove(removedObject);

        foreach(var answer in _answerIcons)
        {
            if(answer.sprite == null)
            { 
                answer.sprite = _matchableIcons[UnityEngine.Random.Range(0, _matchableIcons.Count)];
            }
        }
        //re-adds it back so it can be used again. 
        _matchableIcons.Add(removedObject);
    }

    private void AddScore()
    {
        _score++;
        //update UI;
        _gameUI.UpdateScoreText(_score);

        _profileManager.IncreaseScore();
    }
}
