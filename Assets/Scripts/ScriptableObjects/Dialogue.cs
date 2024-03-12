using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "DialogueObject/Dialogue")]
public class Dialogue : ScriptableObject
{
    public int dialogueID;
    public string[] lines;
    public Sprite[] icons;
}