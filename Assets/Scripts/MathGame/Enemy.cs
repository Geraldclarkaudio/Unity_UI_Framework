using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    Animator _anim;

    [SerializeField]
    private Slider _enemyHealthSlider;
    [SerializeField]
    private Player _player;

    public static Action OnDefeat;

    private ProfileManager _profileManager;

    private void Start()
    {
        _profileManager = FindObjectOfType<ProfileManager>();
        _health = 3;
    }
    public void PlayAnimation(string animationToPlay)
    {
        switch (animationToPlay)
        {
            case "Attack":
                DoDamage();
                break;
        }

        _anim.Play(animationToPlay);
    }

    public void DoDamage()
    {
        _player.TakeDamage();   
    }

    public void TakeDamage()
    {
        _health--;
        _enemyHealthSlider.value = _health;
        if (_health < 1)
        {
            //set score in profile. +1 
            _profileManager.IncreaseLevel();
            //unload math game. Load results canvas 
            OnDefeat?.Invoke();
        }
    }
}
