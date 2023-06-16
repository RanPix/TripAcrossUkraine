using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Tile _currentTile;
    [SerializeField] private Tile _nextTile;

    [SerializeField] private Vector2 _playerPosition;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void SetNextTile()
    {
        //_tilemap.GetTilesBlock()
        TileBase basse = _tilemap.GetTile(new Vector3Int());
        
    }
}
