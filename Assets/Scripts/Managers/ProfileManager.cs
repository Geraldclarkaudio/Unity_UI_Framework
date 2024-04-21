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
        ProfilePlayButton _profilePlayButton = FindObjectOfType<ProfilePlayButton>(true);

        if(selectedProfileIndex == 0)
        {
            Debug.Log("YOU CLICKED PROFILE 1");
            profiles[selectedProfileIndex].level = saveManager.loadedLevel;
        }
        if(selectedProfileIndex == 1)
        {
            Debug.Log("YOU SELECTED PROFILE 2");
            profiles[selectedProfileIndex].level = saveManager.loadedScore;
        }
        if (selectedProfileIndex == 2)
        {
            Debug.Log("YOU SELECTED PROFILE 3");
            profiles[selectedProfileIndex].level = saveManager.loadedBubbles;
        }

        if (_profilePopUp != null)
        {
            _profilePopUp.gameObject.SetActive(true);
            _profilePopUp.SetPopUpData(profiles[selectedProfileIndex].avatar,
                                       profiles[selectedProfileIndex].profileName,
                                       profiles[selectedProfileIndex].level,
                                       profiles[selectedProfileIndex].level);
        }

        _profilePlayButton.ID = profiles[selectedProfileIndex].ID;
    }

    public void IncreaseLevel() //math game
    {
        profiles[selectedProfileIndex].level++;
        saveManager.loadedLevel = profiles[selectedProfileIndex].level;
        PlayerPrefs.SetInt("CurrentLevel", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }

    public void IncreaseScore() // matching Game
    {
        profiles[selectedProfileIndex].level++;
        saveManager.loadedScore = profiles[selectedProfileIndex].level;
        PlayerPrefs.SetInt("CurrentScore", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }
    public void WinBubbles()
    {
        profiles[selectedProfileIndex].level = 1;
        saveManager.loadedBubbles = profiles[selectedProfileIndex].level;
        PlayerPrefs.SetInt("WonBubbles", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }
}