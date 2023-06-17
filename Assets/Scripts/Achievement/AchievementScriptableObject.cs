using UnityEngine;
[CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObjects/AchievementScriptableObject")]
public class AchievementScriptableObject : ScriptableObject
{
    public Texture mainIcon;
    
    [Space]
    
    public Texture icon1;
    public Texture icon2;
    
    [Space]
    
    public string name;
    public string description;
}
