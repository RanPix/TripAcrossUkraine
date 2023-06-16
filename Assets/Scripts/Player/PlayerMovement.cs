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
        _currentTile = TileGrid.instance.GetFirstRoadTile();
        SetNextTile();
        Move();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move();
        }
    }


    public void Move()
    {
        _transform.position = _nextTile.Position;
        _previousTile = _currentTile;
        _currentTile = _nextTile;
        SetNextTile();
    }


    private Tile SetNextTile()
    {
        print(_currentTile.gridPosition);
        Tile[] _tiles = TileGrid.instance.GetNeumannNeighbourTiles(_currentTile);
        foreach (var tile in _tiles)
        {
            if(tile == _previousTile)
                continue;
            if(tile.type != TileType.Road)
                continue;
            _nextTile = tile;
            return tile;
        }

        return null;
    }
}
