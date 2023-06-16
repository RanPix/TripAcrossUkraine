using UnityEngine;

namespace TileMap
{
    public class TileMap : MonoBehaviour
    {
        public TileType tileType;
        
        [SerializeField] private Sprite _sprite;
        //[SerializeField] private Structure _structure;
        public Tile _currentTile;
        
    }
}