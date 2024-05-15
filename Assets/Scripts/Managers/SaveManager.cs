using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    ProfileManager profileManager;

    public int loadedLevel;
    public int loadedScore;
    public int loadedBubbles;

    //profile 1
    public int P1game1loadedLevel;
    public int P1game2loadedLevel;
    public int P1game3loadedLevel;
    //profile 2
    public int P2game1loadedLevel;
    public int P2game2loadedLevel;
    public int P2game3loadedLevel;
    //profile 3
    public int P3game1loadedLevel;
    public int P3game2loadedLevel;
    public int P3game3loadedLevel;

    void Awake()
    {   
        profileManager = FindObjectOfType<ProfileManager>();

        // game 1
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            P1game1loadedLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        if (PlayerPrefs.HasKey("CurrentLevelP2"))
        {
            P2game1loadedLevel = PlayerPrefs.GetInt("CurrentLevelP2");
        }
        if (PlayerPrefs.HasKey("CurrentLevelP3"))
        {
            P3game1loadedLevel = PlayerPrefs.GetInt("CurrentLevelP3");
        }

        //game 2
        if (PlayerPrefs.HasKey("CurrentScore"))
        {
            P1game2loadedLevel = PlayerPrefs.GetInt("CurrentScore");
        }
        if (PlayerPrefs.HasKey("CurrentScoreP2"))
        {
            P2game2loadedLevel = PlayerPrefs.GetInt("CurrentScoreP2");
        }
        if (PlayerPrefs.HasKey("CurrentScoreP3"))
        {
            P3game2loadedLevel = PlayerPrefs.GetInt("CurrentScoreP3");
        }

        //game 3
        if (PlayerPrefs.HasKey("WonBubbles"))
        {
            Debug.Log("PlayerPrefs has key WonBubbles");
            P1game3loadedLevel = PlayerPrefs.GetInt("WonBubbles");
        }
        if (PlayerPrefs.HasKey("WonBubblesP2"))
        {
            Debug.Log("PlayerPrefs has key WonBubbles");
            P2game3loadedLevel = PlayerPrefs.GetInt("WonBubblesP2");
        }
        if (PlayerPrefs.HasKey("WonBubblesP3"))
        {
            Debug.Log("PlayerPrefs has key WonBubbles");
            P3game3loadedLevel = PlayerPrefs.GetInt("WonBubblesP3");
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
            PlayerPrefs.SetInt("CurrentLevelP2", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScoreP2", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubblesP2", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        if(profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("CurrentLevelP3", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScoreP3", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubblesP3", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
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
                PlayerPrefs.SetInt("CurrentLevelP2", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
                PlayerPrefs.SetInt("CurrentScoreP2", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
                PlayerPrefs.SetInt("WonBubblesP2", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
            }
            if (profileManager.selectedProfileIndex == 2)
            {
                PlayerPrefs.SetInt("CurrentLevelP3", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
                PlayerPrefs.SetInt("CurrentScoreP3", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
                PlayerPrefs.SetInt("WonBubblesP3", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
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
            PlayerPrefs.SetInt("CurrentLevelP2", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScoreP2", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubblesP2", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        if (profileManager.selectedProfileIndex == 2)
        {
            PlayerPrefs.SetInt("CurrentLevelP3", profileManager.profiles[profileManager.selectedProfileIndex].game1Level);
            PlayerPrefs.SetInt("CurrentScoreP3", profileManager.profiles[profileManager.selectedProfileIndex].game2Level);
            PlayerPrefs.SetInt("WonBubblesP3", profileManager.profiles[profileManager.selectedProfileIndex].game3Level);
        }
        PlayerPrefs.Save();
    }
}
