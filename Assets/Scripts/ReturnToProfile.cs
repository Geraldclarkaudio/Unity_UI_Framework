using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToProfile : MonoBehaviour
{
    Button _thisButton;
    CanvasManager _canvasManager;
    FadeEvent _fadeEvent;
    void Start()
    {
        _fadeEvent = FindObjectOfType<FadeEvent>();
        _canvasManager = FindObjectOfType<CanvasManager>();
        _thisButton = GetComponent<Button>();    
        _thisButton.onClick.AddListener(() => _canvasManager.DisableCurrentCanvases());
        _thisButton.onClick.AddListener(() => _canvasManager.EnableAppropriateCanvases("ProfileCanvas"));
        _thisButton.onClick.AddListener(() => _fadeEvent.FadeOut());
    }
}
