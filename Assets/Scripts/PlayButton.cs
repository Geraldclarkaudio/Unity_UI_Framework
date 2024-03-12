using UnityEngine;
using UnityEngine.UI;
public class PlayButton : MonoBehaviour
{
    [SerializeField]
    Animator _anim;
    private Button _button;
    private CanvasManager _canvasManager;
    private FadeEvent _fadeEvent;
    private void Start()
    {
        _fadeEvent = FindObjectOfType<FadeEvent>();
        _canvasManager = FindObjectOfType<CanvasManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(_canvasManager.DisableCurrentCanvases);
        _button.onClick.AddListener(()  => _canvasManager.EnableAppropriateCanvases("ProfileCanvas"));
        _button.onClick.AddListener(() => _fadeEvent.FadeOut());
    }
    public void PlayAnimation()
    {
        _anim.Play("PlayButton_Clicked_Anim"); // play animation
    }

}
