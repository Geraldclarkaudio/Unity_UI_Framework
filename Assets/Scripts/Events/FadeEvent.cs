using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeEvent : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    private void OnEnable()
    {
        Enemy.OnDefeat += FadeOut;
        Player.OnDefeat += FadeOut;
    }
    private void Awake()
    {
        Invoke("FadeIn", 1.0f); //go from black to 0
    }
    public void FadeOut() // from 0 to 1
    {
        _anim.Play("FadeOut");
        StartCoroutine(FadeBackIn());
    }
    IEnumerator FadeBackIn()
    {
        yield return new WaitForSeconds(2.0f);
        FadeIn();
    }
    public void FadeIn() //from 1  to 0
    {
        _anim.Play("FadeIn");
    }
}
