using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bubble : MonoBehaviour
{
    Rigidbody2D _rb;
    Vector3[] _direction;

    [SerializeField]
    TMP_Text _text;

    BubbleSpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _direction = new Vector3[4];
        _direction[0] = Vector3.right;
        _direction[1] = Vector3.left;
        _direction[2] = Vector3.up;
        _direction[3] = Vector3.down;


        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity =  _direction[Random.Range(0, _direction.Length)]* 300;
        //set text to element in the array on the manager. 
    }

    public void SetText(int text)
    {
        _text.text = text.ToString();
    }

}
