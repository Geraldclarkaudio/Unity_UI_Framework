using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Profiling;
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
    [SerializeField]
    private int _profileID;
    private Animator _animator;

    [SerializeField]
    private Slider _game1Slider;
    [SerializeField]
    private Slider _game2Slider;
    [SerializeField]
    private Slider _game3Slider;

    [SerializeField]
    private TMP_Text game1Level;
    [SerializeField]
    private TMP_Text game2Level;
    [SerializeField]
    private TMP_Text game3Level;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetPopUpData(Sprite profileAvatar, string profileName, int game1SliderValue, int game2SliderValue, int game3SliderValue)
    {
        _avatar.sprite = profileAvatar;
        _profileName.text = profileName;
        //szet slider values
        _game1Slider.value = game1SliderValue;
        _game2Slider.value = game2SliderValue;
        _game3Slider.value = game3SliderValue;
        //set game level text next to slider
        game1Level.text = game1SliderValue.ToString();
        game2Level.text = game2SliderValue.ToString();
        game3Level.text = game3SliderValue.ToString();

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
