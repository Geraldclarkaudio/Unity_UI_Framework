using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3[] _direction;
    Button _thisButton;
    [SerializeField]
    TMP_Text _text;

    BubbleSpawnManager _spawnManager;
    [SerializeField]
    private bool _canPop;

    [SerializeField]
    private int _popOrder;

    BubbleGameManager _bubbleGameManager;

    // Start is called before the first frame update
    void Start()
    {
        _bubbleGameManager = FindObjectOfType<BubbleGameManager>();

        _thisButton = GetComponent<Button>();
        
        _thisButton.onClick.AddListener(() =>
        {
            ClickedBubble();
        });

        _direction = new Vector3[4];
        _direction[0] = Vector3.right;
        _direction[1] = Vector3.left;
        _direction[2] = Vector3.up;
        _direction[3] = Vector3.down;


        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity =  _direction[Random.Range(0, _direction.Length)]* 300;
    }

    public void SetText(int text)
    {
        _text.text = text.ToString(); // sets the text given to this method via the spawn manager as the string for what to display in the bubble.
    }

    public void SetOrder(int popOrder)
    {
        _popOrder = popOrder;
    }

    public void ClickedBubble()
    {
        //if it can pop, pop it. 
        if(_bubbleGameManager._currentPopOrder == _popOrder)
        {
            this.gameObject.SetActive(false);
            _bubbleGameManager.IncrementPopOrder();
        }
    }

}
