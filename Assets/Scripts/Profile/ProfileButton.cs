using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ProfileButton : MonoBehaviour
{
    [SerializeField]
    private ProfileManager profileManager;
    [SerializeField]
    private Button _button;

    public int profileID;

    // Start is called before the first frame update
    void Awake()
    {
        profileManager = FindObjectOfType<ProfileManager>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => profileManager.SelectProfile(profileID));
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => profileManager.SelectProfile(profileID));
    }
}
