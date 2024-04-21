using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    ProfileManager profileManager;

    public int loadedLevel;
    public int loadedScore;
    public int loadedBubbles;

    // Start is called before the first frame update
    void Awake()
    {   
        profileManager = FindObjectOfType<ProfileManager>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            Debug.Log("PlayerPrefs has key CurrentLevel");
             loadedLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            Debug.Log("PlayerPrefs has key CurrentScore");

            loadedScore = PlayerPrefs.GetInt("CurrentScore");
        }
        if (PlayerPrefs.HasKey("WonBubbles"))
        {
            Debug.Log("PlayerPrefs has key WonBubbles");

            loadedBubbles = PlayerPrefs.GetInt("WonBubbles");
        }
    }

    private void OnApplicationQuit()
    {
        if(profileManager.selectedProfileIndex == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        if(profileManager.selectedProfileIndex == 1)
        {
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        if(profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool paauseStatus)
    {
        if (paauseStatus )
        {
            if (profileManager.selectedProfileIndex == 0)
            {
                PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].level);
            }
            if (profileManager.selectedProfileIndex == 1)
            {
                PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].level);
            }
            if (profileManager.selectedProfileIndex == 2)
            {
                PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].level);
            }
            PlayerPrefs.Save();
        }
    }
    private void OnDestroy()
    {
        if (profileManager.selectedProfileIndex == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        if (profileManager.selectedProfileIndex == 1)
        {
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        if (profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].level);
        }
        PlayerPrefs.Save();
    }
}
