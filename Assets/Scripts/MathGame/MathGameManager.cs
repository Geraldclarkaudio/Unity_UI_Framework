using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathGameManager : MonoBehaviour
{
    public int a;
    public int b;
    public int c;

    public TMP_Text _number1Text;
    public TMP_Text _number2Text;

    public TMP_Text[] _answerText;

    private int randomAnswerIndex;

    public bool _gameWon;
    private Player _player;
    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
       randomAnswerIndex = Random.Range(0, _answerText.Length);
        StartMathGame();
    }
    public void StartMathGame()
    {
        _gameWon = false;
        CreateRandomNumbers();// creates random numbers to add together. 
        CreateAnswers(); // creates answers based off those random numbers
    }
    public void CreateRandomNumbers()
    {
        a = Random.Range(0, 100);
        b = Random.Range(0, 100);
    
        _number1Text.text = a.ToString();
        _number2Text.text = b.ToString();
    }

    public void CreateAnswers()
    {
        c = a + b;
        //picks a random answer button and assigns c to it.
        _answerText[randomAnswerIndex].text = c.ToString();
        _answerText[randomAnswerIndex].GetComponentInParent<AnswerButton>()._correctAnswer = true;
        //assigns random values to the other button texts. 
        for(int i = 0; i < _answerText.Length; i++)
        {
            if(i != randomAnswerIndex)
            {
                _answerText[i].text = Random.Range(0, 300).ToString();
            }
        }     
    }
    public void PlayerAttack()
    {
        _player.PlayAnimation("Attack");
    }
}
