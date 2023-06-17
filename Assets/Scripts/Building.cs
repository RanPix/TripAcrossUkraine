using TileMap;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Building : MonoBehaviour
{
    public static Building instance;
    private PlayerControls controls;
    public TileType selectedBuilding = TileType.Grass;
    public Action onPlace;

    private void Start()
    {
        if (instance is null)
            instance = this;

        controls = new PlayerControls();
        controls.Player.Enable();

        controls.Player.Select.performed += PlaceBuilding;
    }

    private void PlaceBuilding(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        TileGrid.instance.CreateTile(mousePosition, new TileCreateArgs(selectedBuilding));

        onPlace?.Invoke();
    }
}
