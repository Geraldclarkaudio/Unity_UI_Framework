using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BubbleSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _bubbleCanvas;
    [SerializeField]
    private GameObject[] _bubblePrefab;
    [SerializeField]
    private GameObject[] SpawnPoint;

    [SerializeField]
    private List<int> _numbers;

    private void Start()
    {
        for (int i = 0; i < _numbers.Count; i++)
        {
            _numbers[i] = i + 1;
            SetText(_numbers[i], _bubblePrefab[i]);
        }

        foreach (var bubble in _bubblePrefab)
        {
            bubble.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].transform.position;

            if(bubble.activeInHierarchy == false)
            {
                bubble.SetActive(true);
            }
        }
    }

    public void SetText(int text, GameObject bubbleToAssign)
    {
        bubbleToAssign.GetComponent<Bubble>().SetText(text);
    }
}
