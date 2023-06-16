using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        public static TileGrid instance;

        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private Tile[,] tiles;
        [SerializeField] private float tileSize;
        [SerializeField] private Vector2 origin;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Debug.LogError("TILEGRID INSTANCE ALREADY EXISTS");
        }

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

        /// <returns> Four tiles around tile </returns>
        public Tile[] GetNeumannNeighbourTiles(Tile tile)
        {
            List<Tile> neighburs = new();
            
            if(tile.gridPosition.x > 0) // (-1, 0)
                neighburs[0] = tiles[tile.gridPosition.x - 1, tile.gridPosition.y];

            if(tile.gridPosition.x < gridSize.x - 1) // (1, 0)
                neighburs[1] = tiles[tile.gridPosition.x + 1, tile.gridPosition.y];

            if(tile.gridPosition.y > 0) // (0, -1)
                neighburs[2] = tiles[tile.gridPosition.x, tile.gridPosition.y - 1];

            if(tile.gridPosition.y < gridSize.y - 1) // (0, 1)
                neighburs[3] = tiles[tile.gridPosition.x, tile.gridPosition.y + 1];

            return neighburs.ToArray();
        }

        /// <returns> Eight tiles around tile </returns>
        public Tile[] GetMooreNeighbourTiles(Tile tile)
        {
            List<Tile> neighburs = new();

            bool isntLeftWall = tile.gridPosition.x > 0;
            bool isntRightWall = tile.gridPosition.x < gridSize.x - 1;

            bool isntTopWall = tile.gridPosition.y > 0;
            bool isntBottomWall = tile.gridPosition.y < gridSize.y - 1;

            if (isntLeftWall) // (-1, -1) => (-1, 1)
            {
                if (isntTopWall)
                    neighburs.Add(tiles[tile.gridPosition.x - 1, tile.gridPosition.y - 1]);

                neighburs.Add(tiles[tile.gridPosition.x - 1, tile.gridPosition.y]);

                if (isntBottomWall)
                    neighburs.Add(tiles[tile.gridPosition.x - 1, tile.gridPosition.y + 1]);
            }

            {                  // (0, -1) => (0, 1)
                if (isntTopWall)
                    neighburs.Add(tiles[tile.gridPosition.x, tile.gridPosition.y - 1]);

                neighburs.Add(tiles[tile.gridPosition.x, tile.gridPosition.y]);

                if (isntBottomWall)
                    neighburs.Add(tiles[tile.gridPosition.x, tile.gridPosition.y + 1]);
            }

            if (isntRightWall) // (-1, -1) => (-1, 1)
            {
                if (isntTopWall)
                    neighburs.Add(tiles[tile.gridPosition.x + 1, tile.gridPosition.y - 1]);

                neighburs.Add(tiles[tile.gridPosition.x + 1, tile.gridPosition.y]);

                if (isntBottomWall)
                    neighburs.Add(tiles[tile.gridPosition.x + 1, tile.gridPosition.y + 1]);
            }


            return neighburs.ToArray();
        }

        private Vector2Int GetTileXY(Vector2 worldPosition)
        {
            return new Vector2Int(Mathf.FloorToInt((worldPosition.x - origin.x) / tileSize),
                                  Mathf.FloorToInt((worldPosition.y - origin.y) / tileSize));
        }

        public Vector2 GetTileWorldPos(Vector2 tilePos)
        {
            return tilePos - origin;
        }

        public void CreateTile(Vector2 spawnPosition, Tile spawnTile)
        {
            Vector2Int gridSpawnPosition = GetTileXY(spawnPosition);

            spawnTile.globalPosition = GetTileWorldPos(gridSpawnPosition);
            tiles[gridSpawnPosition.x, gridSpawnPosition.y] = spawnTile;

            //Instantiate(spawnTile);
        }

        public void AddTile(Tile spawnTile)
        {
            Vector2Int gridSpawnPosition = GetTileXY(spawnTile.gameObject.transform.position);

            spawnTile.globalPosition = GetTileWorldPos(gridSpawnPosition);
            tiles[gridSpawnPosition.x, gridSpawnPosition.y] = spawnTile;
        }
    }
}