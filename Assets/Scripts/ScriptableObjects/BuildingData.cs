using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileMap;

[CreateAssetMenu(fileName = "Building Data", menuName = "Scriptable Objects/BuildingData")]
public class BuildingData : ScriptableObject
{
    [SerializeField] public string BuildingName;
    [SerializeField] public Sprite sprite;
    [SerializeField] public TileType building;
}
