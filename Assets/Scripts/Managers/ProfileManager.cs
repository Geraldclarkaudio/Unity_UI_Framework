using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class is meant to handle saving data and assigning proper avatars, names, levels, etc to UI. 
/// </summary>
public class ProfileManager : MonoBehaviour
{
    public ProfileData[] profiles; // Array of profile data
    [SerializeField]
    private int selectedProfileIndex = 0;

    public void SelectProfile(int index)
    {
        selectedProfileIndex = index;
        //access the ProfilePopUp game object.
        //Since this is a persistant class, I dont want to store a reference to this since
        //it'll be destroyed once the scene changes to the game scene. 
        ProfilePopUp _profilePopUp = FindObjectOfType<ProfilePopUp>(true);
        if (_profilePopUp != null)
        {
            _profilePopUp.gameObject.SetActive(true);
            _profilePopUp.SetPopUpData(profiles[selectedProfileIndex].avatar, 
                                       profiles[selectedProfileIndex].profileName,
                                       profiles[selectedProfileIndex].level, 
                                       profiles[selectedProfileIndex].level);
        }

        // Load saved data for the selected profile (e.g., score)
        // Update UI to display profile info
    }

    public void IncreaseScore()
    {
        profiles[selectedProfileIndex].level = 1;
        PlayerPrefs.SetInt("CurrentLevel", profiles[selectedProfileIndex].level);
        PlayerPrefs.Save();
    }

    // Other functions: CreateProfile, DeleteProfile, etc.
}