using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnswerButton : MonoBehaviour
{
    public bool _correctAnswer;

    [SerializeField]
    private GameObject _thisRectTrans;
    [SerializeField]
    private GameObject _questionMarkPos;
    [SerializeField]
    private Vector3 _originalPos;

    [SerializeField]
    private ParticleSystem _winParticleSystem;

    DialogueManager _dialogueManager;
    MathGameManager _mathGameManager;
    // Start is called before the first frame update
    void Start()
    {
        _originalPos = transform.position;
        _dialogueManager = FindObjectOfType<DialogueManager>();
        _mathGameManager = FindObjectOfType<MathGameManager>();
    }
    public void MoveBackToOriginalPos()
    {
        _thisRectTrans.transform.DOMove(_originalPos, 0f);
    }

    public void Clicked()
    {
        _thisRectTrans.transform.DOMove(_questionMarkPos.transform.position, 0.5f);
        _mathGameManager.turn++;
        if(_correctAnswer )
        {//won the turn
            _mathGameManager._turnWon = true;
        }
        else
        {//lost the turn. 
            _mathGameManager._turnWon= false;
        }

        StartCoroutine(WaitForAnswerMove());
    }

    IEnumerator WaitForAnswerMove()
    {
        yield return new WaitForSeconds(0.75f);
        //progress game forward after answer makes it to the ? location. 
        if ( _correctAnswer )
        { 
            _winParticleSystem.Play();
        }
        else
        {
            
        }
        //start dialogue
        StartCoroutine(StartNewDialogue());
    }
    IEnumerator StartNewDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        MoveBackToOriginalPos();
        _dialogueManager.StartDialgoue();
    }
}
