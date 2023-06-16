using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private Tile[,] tiles;
        [SerializeField] private float tileSize;
        [SerializeField] private Vector2 origin;

        private void Start()
        {
            tiles = new Tile[gridSize.x, gridSize.y];
        }

        private void Update()
        {
            print(GetTileXY(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }

        public Tile[,] GetTiles() => tiles;

        public Tile GetTile(Vector2 tilePosition)
        {
            Vector2Int tileIndex = GetTileXY(tilePosition);
            return tiles[tileIndex.x, tileIndex.y];
        }

        public Tile[] GetNeighbourTiles(Tile tile)
            => GetNeighbourTiles(tile.gridPosition);
        public Tile[] GetNeighbourTiles(Vector2Int tile)
        {
            Tile[] neighburs = new Tile[4];

            //if (tile.x - 1 >= 0)
            neighburs[0] = tiles[tile.x - 1, tile.y];
            neighburs[1] = tiles[tile.x + 1, tile.y];
            neighburs[2] = tiles[tile.x, tile.y - 1];
            neighburs[3] = tiles[tile.x, tile.y + 1];

            return neighburs;
        }

        private Vector2Int GetTileXY(Vector2 worldPosition)
        {
            return new Vector2Int(Mathf.FloorToInt((worldPosition.x - origin.x) / tileSize),
                                  Mathf.FloorToInt((worldPosition.y - origin.y) / tileSize));
        }
    }
}