using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    public static AchievementsManager instance;
    
    
    [SerializeField] private Button _button;

    [SerializeField] private GameObject _achievemtsInfo;
    [SerializeField] private RawImage image1;
    [SerializeField] private RawImage image2;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private AchievementScriptableObject achievementScriptableObject;
    
    public List<string> structureNames = new();

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void TryActivateNewAchievement(string structureName, AchievementScriptableObject achievementScriptableObject)
    {
        if (!structureNames.Contains(structureName))
        {
            this.achievementScriptableObject = achievementScriptableObject;
            structureNames.Add(structureName);
            ActivateAchievementButton();
            
        }
    }
    private void ActivateAchievementButton()
    {
        _button.gameObject.SetActive(true);
        _button.GetComponentInChildren<RawImage>().texture = achievementScriptableObject.mainIcon;
        _button.GetComponentInChildren<TextMeshProUGUI>().text = achievementScriptableObject.name;
    }

    public void DeactivateNewAchievementButton()
    {
        _button.gameObject.SetActive(false);
    }
    public void ActivateAchievementInfo()
    {
        _achievemtsInfo.SetActive(true);
        image1.texture = achievementScriptableObject.icon1;
        image2.texture = achievementScriptableObject.icon2;
        name.text = achievementScriptableObject.name;
        description.text = achievementScriptableObject.description;
    }
    public void DeactivateAchievementInfo()
    {
        _achievemtsInfo.SetActive(false);
    }  
    
}
