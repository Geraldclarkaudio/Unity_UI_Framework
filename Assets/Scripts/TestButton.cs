using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    ProfileManager profileManager;
    // Start is called before the first frame update
    void Start()
    {
        profileManager = FindAnyObjectByType<ProfileManager>();

    }

    public void ScoreUp()
    {
        profileManager.IncreaseScore();
    }
    
    
}
