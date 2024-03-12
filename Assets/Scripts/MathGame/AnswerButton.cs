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

    public void Clicked()
    {
        _thisRectTrans.transform.DOMove(_questionMarkPos.transform.position, 0.5f);

        if(_correctAnswer )
        {
            _mathGameManager._gameWon = true;
            Debug.Log("CORRECT");
        }
        else
        {
            Debug.Log("WRONG");
        }
        StartCoroutine(WaitForAnswerMove());
    }

    IEnumerator WaitForAnswerMove()
    {
        yield return new WaitForSeconds(0.75f);

        if( _correctAnswer )
        {
            Debug.Log("Trigger Short Dialogue and character animations.");
            _winParticleSystem.Play();
            StartCoroutine(StartNewDialogue());
            //deduct enemy health etc. 
        }
        else
        {
            Debug.Log("Enemy says something and character anims");
            ///deduct player health
        }
    }
    IEnumerator StartNewDialogue()
    {
        yield return new WaitForSeconds(1.0f);
        _dialogueManager.StartDialgoue();
    }
}
