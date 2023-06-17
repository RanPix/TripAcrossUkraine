using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

class BuildingPanel : MonoBehaviour
{
    public BuildingData buildingData { get; private set; }
    public Image image;    

    public void SetBuildingData(BuildingData buildingData)
    {
        this.buildingData = buildingData;
        image.sprite = buildingData.sprite;
    }
}