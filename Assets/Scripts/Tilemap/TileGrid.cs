using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        public TileType tileType;
        
        [SerializeField] private Vector2 gridSize;
        [SerializeField] private Tile[,] tiles;

        
        
        public Tile[,] GetTiles() => tiles;
        public Tile[] GetNeighborTiles(Tile tile)
        { 
            Tile[] neighbors = new Tile[4];
        }

    }
}