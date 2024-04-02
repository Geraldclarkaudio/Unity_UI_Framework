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
        _button.onClick.AddListener(AssignListeners);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(AssignListeners);
    }

    private void AssignListeners()
    {
        //unload current canvases.
        _button.onClick.AddListener(canvasManager.DisableCurrentCanvases);
        //fade out. 
        _button.onClick.AddListener(() => fadeEvent.FadeOut());

        switch (ID)
        {
            case 0:
                _button.onClick.AddListener(() => canvasManager.EnableAppropriateCanvases("MathGame"));
                break;
            case 1:
                _button.onClick.AddListener(() => canvasManager.EnableAppropriateCanvases("MatchingGame"));
                break;
            case 2:
                _button.onClick.AddListener(() => canvasManager.EnableAppropriateCanvases("MatchingGame"));
                break;
        }


    }
}
