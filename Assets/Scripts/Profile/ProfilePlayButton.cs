using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfilePlayButton : MonoBehaviour
{
    Button _button;
    [SerializeField]
    CanvasManager canvasManager;
    FadeEvent fadeEvent;
    public int ID;

    private void Awake()
    {
        fadeEvent = FindObjectOfType<FadeEvent>();
        _button = GetComponent<Button>();
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    private void OnEnable()
    {
        //_button.onClick.AddListener(AssignListeners);
        _button.onClick.AddListener(AssignListeners);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(AssignListeners);
    }

    private void AssignListeners()
    {
        canvasManager.DisableCurrentCanvases();
        fadeEvent.FadeOut();

        switch (ID)
        {
            case 0:
                canvasManager.EnableAppropriateCanvases("MathGame");
                break;
            case 1:
                canvasManager.EnableAppropriateCanvases("MatchingGame");
                break;
            case 2:
                canvasManager.EnableAppropriateCanvases("Bubble_Game");
                break;
        }
    }
}
