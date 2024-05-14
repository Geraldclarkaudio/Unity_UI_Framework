using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    private int _gameID;
    private CanvasManager canvasManager;
    FadeEvent fadeEvent;
    private void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        fadeEvent = FindObjectOfType<FadeEvent>();
    }
    public void EnableGameCanvas()
    {
        canvasManager.DisableCurrentCanvases();
        fadeEvent.FadeOut();

        switch (_gameID)
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
