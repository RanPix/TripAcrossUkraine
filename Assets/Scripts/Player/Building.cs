using TileMap;
using UnityEngine;
using UnityEngine.InputSystem;

public class Building : MonoBehaviour
{
    private PlayerControls controls;

    private void Start()
    {
        controls = new PlayerControls();
        controls.Player.Enable();

        controls.Player.Select.performed += PlaceBuilding;
    }

    private void Update()
    {
        
    }

    private void PlaceBuilding(InputAction.CallbackContext context)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        TileGrid.instance.CreateTile(mousePosition, new TileCreateArgs(TileType.Forest));
    }
}
