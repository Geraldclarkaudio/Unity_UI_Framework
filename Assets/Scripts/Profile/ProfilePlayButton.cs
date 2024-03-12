using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfilePlayButton : MonoBehaviour
{
    Button _button;
    CanvasManager canvasManager;
    FadeEvent fadeEvent;
    private void Start()
    {
        fadeEvent = FindObjectOfType<FadeEvent>();
        _button = GetComponent<Button>();
        canvasManager = FindObjectOfType<CanvasManager>();
        _button.onClick.AddListener(canvasManager.DisableCurrentCanvases);
        _button.onClick.AddListener(() => canvasManager.EnableAppropriateCanvases("MathGame"));
        _button.onClick.AddListener(() => fadeEvent.FadeOut());
    }
}
