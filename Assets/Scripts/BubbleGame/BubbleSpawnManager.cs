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
    private GameObject[] SpawnPoint; // where it spawns

    [SerializeField]
    private List<int> _numbers; // the list of possible numbers in the bubbles.

    private void Start()
    {
        for (int i = 0; i < _numbers.Count; i++)
        {
            _numbers[i] = i + 1; // makes 0 -> 1 and 2 ->3 and so on. 

            SetBubbleText(_numbers[i], _bubblePrefab[i]); // set what the text is.
        }

        foreach (var bubble in _bubblePrefab) // for ach bubble prefab in the list
        {
            bubble.transform.position = SpawnPoint[Random.Range(0, SpawnPoint.Length)].transform.position;
            //set the bubble's position to a random spawn point in the SpawnPoint array's position. 
            if(bubble.activeInHierarchy == false)
            {
                bubble.SetActive(true);//turn on the bubble. 
            }
        }
    }

    public void SetBubbleText(int text, GameObject bubbleToAssign)
    {
        //set the bubble's text and pop order.
        bubbleToAssign.GetComponent<Bubble>().SetText(text);
        bubbleToAssign.GetComponent<Bubble>().SetOrder(text);
    }
}
