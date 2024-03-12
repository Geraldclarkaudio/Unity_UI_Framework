using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ProfileButton : MonoBehaviour
{
    [SerializeField]
    private ProfileManager profileManager;
    private Button _button;
    [SerializeField]
    private int profileID;
    // Start is called before the first frame update
    void Start()
    {
        profileManager = FindObjectOfType<ProfileManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => profileManager.SelectProfile(profileID));
    }
}
