using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public Dialogue[] _dialogues;

    public Dialogue currentDialogue;
    public int keyIndex; // which index of the keys for that dialogue
    public int dialogueIndex;//which dialogue asset
    
    [SerializeField]
    private TMP_Text _dialogueText;
    [SerializeField]
    private Image _iconImage;
    public GameObject dialogueGameObject;
    
    public bool dialogueIsActive;

    [SerializeField]
    Canvas mathGameCanvas;
    private MathGameManager _mathGameManager;

    private void Start()
    {
        currentDialogue = _dialogues[0];
        _mathGameManager = FindAnyObjectByType<MathGameManager>();
        StartDialgoue();
    }


    public void StartDialgoue()
    {
        mathGameCanvas.enabled = false;
        currentDialogue = _dialogues[dialogueIndex];
        
        if(_mathGameManager.turn != 0)
        {
            if (_mathGameManager._turnWon == true)
            {
                currentDialogue = _dialogues[1];
            }
            else
            {
                currentDialogue = _dialogues[2];
            }
        }


        keyIndex = 0;//reset keys back to 0
        dialogueIndex = currentDialogue.dialogueID;
        dialogueIsActive = true;
        _dialogueText.text = currentDialogue.lines[keyIndex];
        dialogueGameObject.SetActive(true);
        _iconImage.sprite = currentDialogue.icons[keyIndex];
    }

    public void NextLine()
    {
        if(keyIndex < currentDialogue.lines.Length -1 ) 
        {
            keyIndex++;
            _dialogueText.text = currentDialogue.lines[keyIndex];
            _iconImage.sprite = currentDialogue.icons[keyIndex];
        }

        else if (keyIndex >= currentDialogue.lines.Length - 1)
        {
            dialogueGameObject.SetActive(false);
            //dialogueIndex++;
            dialogueIsActive = false;

            //won turn? 
            //play attack animations 
            //start new dialogue

            if(_mathGameManager._turnWon == false)
            {
                if(_mathGameManager.turn != 0)
                {
                    _mathGameManager.EnemyAttack();
                }
            }
            else if(_mathGameManager._turnWon == true)
            {
                _mathGameManager._turnWon = false;
                _mathGameManager.PlayerAttack();
            }
            _mathGameManager.StartMathGame();
            mathGameCanvas.enabled = true;
        }
    }
}
