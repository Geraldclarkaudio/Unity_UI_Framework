using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class is meant to handle saving data and assigning proper avatars, names, levels, etc to UI. 
/// </summary>
public class ProfileManager : MonoBehaviour
{
    public ProfileData[] profiles; // Array of profile data
    [SerializeField]
    public int selectedProfileIndex = 0;

    SaveManager saveManager;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }
    public void SelectProfile(int index)
    {
        selectedProfileIndex = index;
        ProfilePopUp _profilePopUp = FindObjectOfType<ProfilePopUp>(true);

        if(selectedProfileIndex == 0)
        {
            Debug.Log("YOU CLICKED PROFILE 1");
            //check all the level info for each game and set it accordingly 
            profiles[selectedProfileIndex].game1Level = saveManager.P1game1loadedLevel;
            profiles[selectedProfileIndex].game2Level = saveManager.P1game2loadedLevel;
            profiles[selectedProfileIndex].game3Level = saveManager.P1game3loadedLevel;

        }
        if (selectedProfileIndex == 1)
        {
            Debug.Log("YOU SELECTED PROFILE 2");
            //profiles[selectedProfileIndex].game1Level = saveManager.game1loadedLevel;
            //profiles[selectedProfileIndex].game2Level = saveManager.game2loadedLevel;
            //profiles[selectedProfileIndex].game3Level = saveManager.game3loadedLevel;
        }
        if (selectedProfileIndex == 2)
        {
            Debug.Log("YOU SELECTED PROFILE 3");
            //profiles[selectedProfileIndex].game1Level = saveManager.game1loadedLevel;
            //profiles[selectedProfileIndex].game2Level = saveManager.game2loadedLevel;
            //profiles[selectedProfileIndex].game3Level = saveManager.game3loadedLevel;
        }

        if (_profilePopUp != null) // just populate the profile pop up with proper data. 
        {
            _profilePopUp.gameObject.SetActive(true);
            _profilePopUp.SetPopUpData(profiles[selectedProfileIndex].avatar,
                                       profiles[selectedProfileIndex].profileName,
                                       profiles[selectedProfileIndex].game1Level,
                                       profiles[selectedProfileIndex].game2Level,
                                       profiles[selectedProfileIndex].game3Level);
        }
    }

    public void IncreaseLevel() //math game
    {
         //increase the currently selected profile's game1Level by 1
        if(selectedProfileIndex == 0)
        {
            profiles[selectedProfileIndex].game1Level++;
            saveManager.P1game1loadedLevel = profiles[selectedProfileIndex].game1Level; // set the savemanager's loaded value to the game1level value. 
            PlayerPrefs.SetInt("CurrentLevel", profiles[selectedProfileIndex].game1Level);

        }
        if(selectedProfileIndex == 1)
        {
            profiles[selectedProfileIndex].game1Level++;
            saveManager.P2game1loadedLevel = profiles[selectedProfileIndex].game1Level;
            PlayerPrefs.SetInt("CurrentLevelP2", profiles[selectedProfileIndex].game1Level);
        }
        if(selectedProfileIndex == 2)
        {
            profiles[selectedProfileIndex].game1Level++;
            saveManager.P3game1loadedLevel = profiles[selectedProfileIndex].game1Level;
            PlayerPrefs.SetInt("CurrentLevelP3", profiles[selectedProfileIndex].game1Level);
        }
        PlayerPrefs.Save();
    }

    public void IncreaseScore() // matching Game
    {
        if(selectedProfileIndex == 0)
        {
            profiles[selectedProfileIndex].game2Level++;

            saveManager.P1game2loadedLevel = profiles[selectedProfileIndex].game2Level;
            PlayerPrefs.SetInt("CurrentScore", profiles[selectedProfileIndex].game2Level);
        }
        if (selectedProfileIndex == 1)
        {
            profiles[selectedProfileIndex].game2Level++;

            saveManager.P2game2loadedLevel = profiles[selectedProfileIndex].game2Level;
            PlayerPrefs.SetInt("CurrentScoreP2", profiles[selectedProfileIndex].game2Level);
        }
        if (selectedProfileIndex == 2)
        {
            profiles[selectedProfileIndex].game2Level++;

            saveManager.P3game2loadedLevel = profiles[selectedProfileIndex].game2Level;
            PlayerPrefs.SetInt("CurrentScoreP3", profiles[selectedProfileIndex].game2Level);
        }

        PlayerPrefs.Save();
    }
    public void WinBubbles()
    {
        if(selectedProfileIndex == 0)
        {
            profiles[selectedProfileIndex].game3Level = 1;

            saveManager.P1game3loadedLevel = profiles[selectedProfileIndex].game3Level;
            PlayerPrefs.SetInt("WonBubbles", profiles[selectedProfileIndex].game3Level);
        }
        if (selectedProfileIndex == 1)
        {
            profiles[selectedProfileIndex].game3Level = 1;

            saveManager.P2game3loadedLevel = profiles[selectedProfileIndex].game3Level;
            PlayerPrefs.SetInt("WonBubblesP2", profiles[selectedProfileIndex].game3Level);
        }
        if (selectedProfileIndex == 2)
        {
            profiles[selectedProfileIndex].game3Level = 1;

            saveManager.P3game3loadedLevel = profiles[selectedProfileIndex].game3Level;
            PlayerPrefs.SetInt("WonBubblesP3", profiles[selectedProfileIndex].game3Level);
        }

        PlayerPrefs.Save();
    }
}