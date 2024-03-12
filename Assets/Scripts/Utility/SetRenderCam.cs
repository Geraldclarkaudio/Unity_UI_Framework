using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas thisCanvas = GetComponent<Canvas>();
        thisCanvas.worldCamera = Camera.main;
    }

}
