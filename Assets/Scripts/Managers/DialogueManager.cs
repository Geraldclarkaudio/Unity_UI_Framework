using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    Dialogue[] _dialogues;

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
        _mathGameManager = FindAnyObjectByType<MathGameManager>();
        StartDialgoue();
    }


    public void StartDialgoue()
    {
        mathGameCanvas.enabled = false;
        currentDialogue = _dialogues[dialogueIndex];
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
            dialogueIndex++;
            dialogueIsActive = false;

            if(_mathGameManager._gameWon == false)
            {
                mathGameCanvas.enabled = true;
            }
            else if(_mathGameManager._gameWon == true)
            {
                _mathGameManager._gameWon = false;
                _mathGameManager.StartMathGame();
            }

        }
    }
}
