using TileMap;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tile _previousTile;
    [SerializeField] private Tile _currentTile;
    [SerializeField] private Tile _nextTile;

    [SerializeField] private Transform _transform;
    
    void Start()
    {
        CharacterAndUIConnector.instance.ConnectUI(this);
        _currentTile = TileGrid.instance.GetFirstRoadTile();
        SetNextTile();
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move();
        }
    }


    private void Move()
    {
        _transform.position = new Vector3(_nextTile.Position.x, _nextTile.Position.y, -0.1f);
        
        _previousTile = _currentTile;
        _currentTile = _nextTile;
        SetNextTile();
        
        _currentTile.OnPlayerEnter?.Invoke();
    }


    private Tile SetNextTile()
    {
        print(_currentTile.gridPosition);
        Tile[] _tiles = TileGrid.instance.GetNeumannNeighbourTiles(_currentTile);
        foreach (var tile in _tiles)
        {
            if(tile == _previousTile || !tile)
                continue;
                if(tile.type != TileType.Road)
                continue;
            _nextTile = tile;
            return tile;
        }

        return null;
    }
}
