using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPanelsCreator : MonoBehaviour
{
    [SerializeField] BuildingData[] buildingDatas;
    [SerializeField] GameObject buildingPanelPrefab;
    List<GameObject> buildingPanels;


    private void Awake()
    {
        buildingPanels = new List<GameObject>();
        for (int i = 0; i < buildingDatas.Length; i++)
        {
            GameObject buildingPanel = Instantiate(buildingPanelPrefab, transform);
            buildingPanels.Add(buildingPanel);
        }
    }

    private void Start()
    {
        for (int i = 0; i < buildingDatas.Length; i++)
        {
            buildingPanels[i].GetComponent<BuildingPanel>().SetBuildingData(buildingDatas[i]);
        }
    }
}
