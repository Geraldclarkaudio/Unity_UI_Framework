using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    ProfileManager profileManager;

    // Start is called before the first frame update
    void Awake()
    {   
        profileManager = FindObjectOfType<ProfileManager>();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].level);
        PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].level);
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool paauseStatus)
    {
        if (paauseStatus )
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].level);
            PlayerPrefs.Save();
        }
    }
}
