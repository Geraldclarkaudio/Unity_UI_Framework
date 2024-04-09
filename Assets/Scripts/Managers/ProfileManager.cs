using System;
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
            profiles[selectedProfileIndex].level = PlayerPrefs.GetInt("CurrentLevel");
        }
        else if(selectedProfileIndex == 1)
        {
            profiles[selectedProfileIndex].level = PlayerPrefs.GetInt("CurrentScore");
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
        profiles[selectedProfileIndex].level ++;
        PlayerPrefs.SetInt("CurrentLevel", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }

    public void IncreaseScore() // matching Game
    {
        profiles[selectedProfileIndex].level++;
        PlayerPrefs.SetInt("CurrentScore", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }
}