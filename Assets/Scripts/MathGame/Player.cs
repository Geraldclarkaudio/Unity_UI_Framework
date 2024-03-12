using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    Animator _anim;

    [SerializeField]
    private Slider _playerHealthSlider;

    [SerializeField]
    private Enemy _enemy;

    private void Start()
    {
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
        _enemy.TakeDamage();
    }

    public void TakeDamage()
    {
        _health--;
        _playerHealthSlider.value = _health;   
        if(_health < 0 )
        {
            Debug.Log("You Lose");
        }
    }
}
