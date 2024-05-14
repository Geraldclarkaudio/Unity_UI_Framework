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
        //access the ProfilePopUp game object.
        //Since this is a persistant class, I dont want to store a reference to this since
        //it'll be destroyed once the scene changes to the game scene. 
        ProfilePopUp _profilePopUp = FindObjectOfType<ProfilePopUp>(true);

        if(selectedProfileIndex == 0)
        {
            Debug.Log("YOU CLICKED PROFILE 1");
            //check all the level info for each game and set it accordingly 
            profiles[selectedProfileIndex].game1Level = saveManager.game1loadedLevel;
            profiles[selectedProfileIndex].game2Level = saveManager.game2loadedLevel;
            profiles[selectedProfileIndex].game3Level = saveManager.game3loadedLevel;

        }
        if (selectedProfileIndex == 1)
        {
            Debug.Log("YOU SELECTED PROFILE 2");
            profiles[selectedProfileIndex].game1Level = saveManager.game1loadedLevel;
            profiles[selectedProfileIndex].game2Level = saveManager.game2loadedLevel;
            profiles[selectedProfileIndex].game3Level = saveManager.game3loadedLevel;
        }
        if (selectedProfileIndex == 2)
        {
            Debug.Log("YOU SELECTED PROFILE 3");
            profiles[selectedProfileIndex].game1Level = saveManager.game1loadedLevel;
            profiles[selectedProfileIndex].game2Level = saveManager.game2loadedLevel;
            profiles[selectedProfileIndex].game3Level = saveManager.game3loadedLevel;
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
        profiles[selectedProfileIndex].game1Level++; //increase the currently selected profile's game1Level by 1
        saveManager.game1loadedLevel = profiles[selectedProfileIndex].game1Level; // set the savemanager's loaded value to the game1level value. 
        PlayerPrefs.SetInt("CurrentLevel", profiles[selectedProfileIndex].game1Level);
        PlayerPrefs.Save();
    }

    public void IncreaseScore() // matching Game
    {
        profiles[selectedProfileIndex].game2Level++;
        saveManager.game2loadedLevel = profiles[selectedProfileIndex].game2Level;
        PlayerPrefs.SetInt("CurrentScore", profiles[selectedProfileIndex].game2Level);
        PlayerPrefs.Save();
    }
    public void WinBubbles()
    {
        profiles[selectedProfileIndex].game3Level = 1;
        saveManager.game3loadedLevel = profiles[selectedProfileIndex].game3Level;
        PlayerPrefs.SetInt("WonBubbles", profiles[selectedProfileIndex].game3Level);
        PlayerPrefs.Save();
    }
}