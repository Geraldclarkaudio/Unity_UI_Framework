using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    ProfileManager profileManager;

    public int loadedLevel;
    public int loadedScore;
    public int loadedBubbles;

    public int game1loadedLevel;
    public int game2loadedLevel;
    public int game3loadedLevel;

    // Start is called before the first frame update
    void Awake()
    {   
        profileManager = FindObjectOfType<ProfileManager>();

        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            Debug.Log("PlayerPrefs has key CurrentLevel");
            game1loadedLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            Debug.Log("PlayerPrefs has key CurrentScore");

            game2loadedLevel = PlayerPrefs.GetInt("CurrentScore");
        }
        if (PlayerPrefs.HasKey("WonBubbles"))
        {
            Debug.Log("PlayerPrefs has key WonBubbles");

            game3loadedLevel = PlayerPrefs.GetInt("WonBubbles");
        }
    }

    private void OnApplicationQuit()
    {
        if(profileManager.selectedProfileIndex == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        if(profileManager.selectedProfileIndex == 1)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        if(profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        PlayerPrefs.Save();
    }
    private void OnApplicationPause(bool paauseStatus)
    {
        if (paauseStatus )
        {
            if (profileManager.selectedProfileIndex == 0)
            {
                PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
                PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
                PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
            }
            if (profileManager.selectedProfileIndex == 1)
            {
                PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
                PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
                PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
            }
            if (profileManager.selectedProfileIndex == 2)
            {
                PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
                PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
                PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
            }
            PlayerPrefs.Save();
        }
    }
    private void OnDestroy()
    {
        if (profileManager.selectedProfileIndex == 0)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);

        }
        if (profileManager.selectedProfileIndex == 1)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        if (profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("CurrentLevel", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScore", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubbles", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        PlayerPrefs.Save();
    }
}
