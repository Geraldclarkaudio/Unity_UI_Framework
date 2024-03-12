using UnityEngine;

[CreateAssetMenu(fileName = "New Profile", menuName = "Profiles/Profile Data")]
public class ProfileData : ScriptableObject
{
    public Sprite avatar;
    public string profileName;
    public int level;
    // Add other profile-related data here
}