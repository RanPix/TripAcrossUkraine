using UnityEngine;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        public TileType tileType;
        
        [SerializeField] private Vector2 gridSize;
        [SerializeField] private Tile[,] tiles;

        
        
        public Tile[,] GetTiles() => tiles;
        public Tile[] GetNeighbourTiles(Tile tile)
        { 
            Tile[] neighburs = new Tile[4];

            neighburs[0] = tiles[tile.gridPosition.x - 1, tile.gridPosition.y];
            neighburs[1] = tiles[tile.gridPosition.x + 1, tile.gridPosition.y];
            neighburs[2] = tiles[tile.gridPosition.x, tile.gridPosition.y - 1];
            neighburs[3] = tiles[tile.gridPosition.x, tile.gridPosition.y + 1];

            return neighburs;
        }
    }
}