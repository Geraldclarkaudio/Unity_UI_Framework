using System;
using TMPro;
using UnityEngine;
/// <summary>
/// This class is intended to handle math game logic. Creating the numbers to add and creating the answers to use. 
/// It is also meant to keep track of how many questions the player got right and wrong. 
/// </summary>
public class MathGameManager : MonoBehaviour
{
    public int a;
    public int b;
    public int c;

    public TMP_Text _number1Text;
    public TMP_Text _number2Text;

    public TMP_Text[] _answerText;

    private int randomAnswerIndex;
    public int turn;
    public bool _turnWon;
    private Player _player;
    private Enemy _enemy;

    private void Start()
    {
        turn = 0;
        _player = FindObjectOfType<Player>();
        _enemy = FindObjectOfType<Enemy>();
        randomAnswerIndex = UnityEngine.Random.Range(0, _answerText.Length);
        StartMathGame();
    }
    public void StartMathGame()
    {
        _turnWon = false;
        CreateRandomNumbers();// creates random numbers to add together. 
        CreateAnswers(); // creates answers based off those random numbers
    }
    public void CreateRandomNumbers()
    {
        a = UnityEngine.Random.Range(0, 100);
        b = UnityEngine.Random.Range(0, 100);
    
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
                _answerText[i].text = UnityEngine.Random.Range(0, 300).ToString();
            }
        }     
    }
    public void PlayerAttack()
    {
        _player.PlayAnimation("Attack");
    }
    public void EnemyAttack()
    {
        _enemy.PlayAnimation("Attack");
    }
}
