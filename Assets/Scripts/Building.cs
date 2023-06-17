using TileMap;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Building : MonoBehaviour
{
    public static Building instance;
    private PlayerControls controls;
    public TileType selectedBuilding = TileType.Grass;
    public Action<string, AchievementScriptableObject> OnPlace;

    private void Awake()
    {
        if (instance is null)
            instance = this;
    }

    private void Start()
    {
        OnPlace += AchievementsManager.instance.TryActivateNewAchievement;

        controls = new PlayerControls();
        controls.Player.Enable();

        controls.Player.Select.performed += PlaceBuilding;
    }

    private void PlaceBuilding(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        TileGrid.instance.CreateTile(mousePosition, new TileCreateArgs(selectedBuilding));

        OnPlace?.Invoke(selectedBuilding.ToString(), TileGrid.instance.achievementScriptableObjectsDictionary[selectedBuilding]);
    }
}
