using System.Collections.Generic;
using UnityEngine;

namespace TileMap
{
    public class TileGrid : MonoBehaviour
    {
        public TileType tileType;
        
        [SerializeField] private Vector2 gridSize;
        [SerializeField] private Tile[,] tiles;

        
        
        public Tile[,] GetTiles() => tiles;

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
    }
}