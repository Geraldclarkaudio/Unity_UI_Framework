using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImage : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector2 initialPosition;
    private Canvas canvas;
    [SerializeField]
    private RectTransform _answerArea;
    [SerializeField]
    private float distance;
    public bool dragging;
    AnswerIcon _answerIcon;
    [SerializeField]
    private bool _canDrag = true;
    public static Action onResetGame;
    public static Action onScored;

    public DraggableImage[] _draggableImages;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.anchoredPosition;
        canvas = GetComponentInParent<Canvas>();
        _answerIcon = GetComponent<AnswerIcon>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_canDrag == true)
        {
            // Save the initial position when dragging starts
            initialPosition = rectTransform.anchoredPosition;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_canDrag == true)
        {
            dragging = true;
            // Update the position based on drag input
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        // Snap back to the initial position when dragging ends
        if (distance > 250) {
            rectTransform.anchoredPosition = initialPosition;
        }
        else
        {
            if(_answerIcon.answer == false) // wrong? 
            {
                _answerIcon.WrongAnswer();
                rectTransform.anchoredPosition = initialPosition;
            }
            else // right 
            {
                UpdateScore();
                _answerIcon.CelebrationVFX();
                rectTransform.position = _answerArea.position;
                foreach (var image in _draggableImages)
                {
                    image._canDrag = false;
                }
                Invoke("ResetGame", 3.0f);
            }
        }
    }

    public void UpdateScore()
    {
        if(onScored != null)
            onScored();
    }

    public void ResetGame()
    {
        rectTransform.anchoredPosition = initialPosition;
        if(onResetGame != null)
            onResetGame();
        foreach (var image in _draggableImages)
        {
            image._canDrag = true;
        }
    }

    private void Update()
    {
        if (dragging == true)
        {
            distance = Vector2.Distance(rectTransform.position, _answerArea.position);
        }
    }
}
