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
        int loadedLevel = PlayerPrefs.GetInt("CurrentLevel", 
            profileManager.profiles[profileManager.selectedProfileIndex].level);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool paauseStatus)
    {
        PlayerPrefs.Save();
    }
}
