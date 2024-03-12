using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePopUp : MonoBehaviour
{
    [SerializeField]
    private Image _avatar;
    [SerializeField]
    private TMP_Text _profileName;
    [SerializeField]
    private Slider _profileLevelSlider;
    [SerializeField]
    private TMP_Text _profileLevel;

    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetPopUpData(Sprite profileAvatar, string profileName, int sliderValue, int profileLevel)
    {
        _avatar.sprite = profileAvatar;
        _profileName.text = profileName;
        _profileLevelSlider.value = sliderValue;
        _profileLevel.text = profileLevel.ToString();
    }

    public void PlayCloseAnimation()
    {
        _animator.Play("Close");
        Invoke("SetGameObjectInactive", 0.5f);
    }

    private void SetGameObjectInactive()
    {
        this.gameObject.SetActive(false);
    }
}
