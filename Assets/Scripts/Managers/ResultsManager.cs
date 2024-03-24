using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ResultsManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField]
    private Image _backgroundImage;
    [SerializeField]
    private Sprite _lostBG;
    [SerializeField]
    private Sprite _winBG;

    [SerializeField]
    private TMP_Text _text;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        SetBackgroundImageAndText();
    }
    public void SetBackgroundImageAndText()
    {
        if (_gameManager.gameWon == true)
        {
            _backgroundImage.sprite = _winBG;
            _text.text = "You Win!";
        }
        else if (_gameManager.gameWon == false)
        {
            _backgroundImage.sprite = _lostBG;
            _text.text = "You Lose!";
        }
    }
}
