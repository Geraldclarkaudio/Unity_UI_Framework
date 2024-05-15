using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Profiles/Profile Data")]
public class ProfileData : ScriptableObject
{
    public Sprite avatar;
    public string profileName;
    //public int level; //get rid of this eventually
    public int ID;
    public int game1Level;
    public int game2Level;
    public int game3Level;
    // Add other profile-related data here
}