using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchingGameUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    //sets score to the profile manager's current score
    public void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }
}
