using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnswerIcon : MonoBehaviour
{
    public bool answer = false;
    [SerializeField]
    private Image _celebrationImage;
    public void SetAnswer()
    {
        answer = true;
    }
    public void CelebrationVFX()
    {
        StartCoroutine(CelebrationVFXRoutine());
    }
    IEnumerator CelebrationVFXRoutine()
    {
        _celebrationImage.DOFade(1, 0.5f);
        yield return new WaitForSeconds(2.5f);
        _celebrationImage.DOFade(0, 0.5f);
    }
    public void WrongAnswer()
    {
        //wrong answer should do... something
    }
}
