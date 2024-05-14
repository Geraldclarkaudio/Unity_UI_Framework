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

    [SerializeField]
    private AnswerButton _currentAnswerButton;

    [SerializeField]
    private AudioClip[] _attackSound;

    private void Start()
    {
        turn = 0;
        _player = FindObjectOfType<Player>();
        _enemy = FindObjectOfType<Enemy>();
        
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
        //if the currentAnswerButton has already been assigned
        if(_currentAnswerButton != null)
        {//set it false
            _currentAnswerButton._correctAnswer = false;
        }
        //pick a random answer
        randomAnswerIndex = UnityEngine.Random.Range(0, _answerText.Length);
        //set c = a+b
        c = a + b;
        //sets text to c
        _answerText[randomAnswerIndex].text = c.ToString();
        //assign currentanswerbutton
        _currentAnswerButton = _answerText[randomAnswerIndex].GetComponentInParent<AnswerButton>();
        //set answer to true
        _currentAnswerButton._correctAnswer = true;

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
        AudioManager.Instance.PlaySwordSwingSFX(_attackSound[UnityEngine.Random.Range(0,_attackSound.Length)]);
    }
    public void EnemyAttack()
    {
        _enemy.PlayAnimation("Attack");
        AudioManager.Instance.PlaySwordSwingSFX(_attackSound[UnityEngine.Random.Range(0, _attackSound.Length)]);
    }
}
