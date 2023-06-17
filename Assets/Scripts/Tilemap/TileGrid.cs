using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        public static TileGrid instance;

        [SerializeField] private Tilemap tilemap;
        [SerializeField] private TileBase[] tilemapBaseTiles;
        [SerializeField] private RuleTile tilemapBaseRoadTile;

        [SerializeField] private GameObject tilePrefab;

        [SerializeField] private Vector2Int gridSize;
        [SerializeField] private Tile[,] tiles;
        [SerializeField] private float tileSize;
        [SerializeField] private Vector2 origin;


        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Debug.LogError("TILE GRID INSTANCE ALREADY EXISTS");

            tiles = new Tile[gridSize.x, gridSize.y];
        }

        private void Start()
        {
            BuildTilemap();
        }

        private void Update()
        {
            //print(GetTileXY(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
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

            if (tile.gridPosition.x > 0) // (-1, 0)
                neighburs.Add(tiles[tile.gridPosition.x - 1, tile.gridPosition.y]);

            if (tile.gridPosition.x < gridSize.x - 1) // (1, 0)
                neighburs.Add(tiles[tile.gridPosition.x + 1, tile.gridPosition.y]);

            if (tile.gridPosition.y > 0) // (0, -1)
                neighburs.Add(tiles[tile.gridPosition.x, tile.gridPosition.y - 1]);

            if (tile.gridPosition.y < gridSize.y - 1) // (0, 1)
                neighburs.Add(tiles[tile.gridPosition.x, tile.gridPosition.y + 1]);

            return neighburs.ToArray();
        }

        /// <returns> Eight tiles around tile </returns>
        public Tile[] GetMooreNeighbourTiles(Tile tile)
            => GetMooreNeighbourTiles(tile.gridPosition);

        /// <returns> Eight tiles around tile </returns>
        public Tile[] GetMooreNeighbourTiles(Vector2Int tile)
        {
            List<Tile> neighburs = new();

            bool isntLeftWall = tile.x > 0;
            bool isntRightWall = tile.x < gridSize.x - 1;

            bool isntTopWall = tile.y > 0;
            bool isntBottomWall = tile.y < gridSize.y - 1;

            if (isntLeftWall) // (-1, -1) => (-1, 1)
            {
                if (isntTopWall)
                    neighburs.Add(tiles[tile.x - 1, tile.y - 1]);

                neighburs.Add(tiles[tile.x - 1, tile.y]);

                if (isntBottomWall)
                    neighburs.Add(tiles[tile.x - 1, tile.y + 1]);
            }

            {                  // (0, -1) => (0, 1)
                if (isntTopWall)
                    neighburs.Add(tiles[tile.x, tile.y - 1]);
                    
                if (isntBottomWall)
                    neighburs.Add(tiles[tile.x, tile.y + 1]);
            }

            if (isntRightWall) // (-1, -1) => (-1, 1)
            {
                if (isntTopWall)
                    neighburs.Add(tiles[tile.x + 1, tile.y - 1]);

                neighburs.Add(tiles[tile.x + 1, tile.y]);

                if (isntBottomWall)
                    neighburs.Add(tiles[tile.x + 1, tile.y + 1]);
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
            return tilePos + origin + new Vector2(tileSize, tileSize) * 0.5f;
        }

        public void CreateTile(Vector2 spawnPosition, TileCreateArgs spawnTileArgs)
        {
            Vector2Int gridSpawnPosition = GetTileXY(spawnPosition);
            Tile conflictTile = tiles[gridSpawnPosition.x, gridSpawnPosition.y];

            if (conflictTile != null)
            {
                if (conflictTile.type == spawnTileArgs.type)
                    return;

                else if (conflictTile.type == TileType.Road)
                    return;

                else
                {
                    Destroy(conflictTile.gameObject);
                    tiles[gridSpawnPosition.x, gridSpawnPosition.y] = null;
                }
            }

            

            bool hasRoads = false;
            foreach (Tile _tile in GetMooreNeighbourTiles(gridSpawnPosition))
            {
                if (_tile != null)
                {
                    hasRoads = _tile.type == TileType.Road;
                }

                if (hasRoads)
                    break;
            }

            if (!hasRoads)
                return;

            Tile tile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity).GetComponent<Tile>();
            tile.SetArgs(spawnTileArgs);

            Tile[] surroundingTiles = GetMooreNeighbourTiles(gridSpawnPosition);
            foreach (var _tile in surroundingTiles)
            {
                print(_tile);
                _tile?.UpdateSurroundings();
            }
        }

        public void AddTile(Tile spawnTile)
        {
            Vector2Int gridSpawnPosition = GetTileXY(spawnTile.Position);

            spawnTile.Position = GetTileWorldPos(gridSpawnPosition);
            spawnTile.gridPosition = gridSpawnPosition;
            tiles[gridSpawnPosition.x, gridSpawnPosition.y] = spawnTile;

            BuildTilemap();
        }

        public Tile GetFirstRoadTile()
        {
            foreach (var tile in tiles)
            {
                if(!tile)
                    continue;
                //print("cont");
                if(tile.type == TileType.Road) 
                    return tile;
            }
            //print("hello");
            return null;
        }

        private void BuildTilemap()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y ; y++) 
                {
                    if (tiles[x, y])
                        tilemap.SetTile(new Vector3Int(x, y, 0) - new Vector3Int(gridSize.x, gridSize.y, 0) / 2, GetTileBase(tiles[x, y].type));

                    else
                        tilemap.SetTile(new Vector3Int(x, y, 0) - new Vector3Int(gridSize.x, gridSize.y, 0) / 2, GetTileBase(TileType.Grass));
                }
            }
        }

        private TileBase GetTileBase(TileType type)
        {
            if ((int)type < tilemapBaseTiles.Length)
                return tilemapBaseTiles[(int)type];

            else
                return tilemapBaseTiles[0];
        }
    }
}