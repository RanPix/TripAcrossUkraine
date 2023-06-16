using System.Collections.Generic;
using TileMap;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Tile parentTile;
    private Dictionary<EntityType, int> spawnerDatas = new Dictionary<EntityType, int>();
    private Tile[] currentNeighbours;

    private void Start()
    {
        parentTile = GetComponent<Tile>();
    }

    public void Update()
    {
        GetSpawner();
        Spawn();
    }

    public void GetSpawner()
    {
        spawnerDatas.Clear();
        currentNeighbours = TileGrid.instance.GetMooreNeighbourTiles(parentTile);

        foreach (Tile tile in currentNeighbours)
        {
            switch (tile.type)
            {
                case TileType.Forest:
                    if (!spawnerDatas.ContainsKey(EntityType.Wolf))
                        spawnerDatas.Add(EntityType.Wolf, 1);

                    else
                        spawnerDatas[EntityType.Wolf]++;
                    break;
            }
        }
    }

    public void Spawn()
    {
        List<Tile> roads = new List<Tile>();

        foreach (Tile tile in currentNeighbours)
        {
            if (tile.type == TileType.Road)
                roads.Add(tile);
        }

        foreach (KeyValuePair<EntityType, int> entity in spawnerDatas)
        {
            if (Random.Range(0f, entity.Value) > 0.5f)
            {
                // spawn
            }
        }
    }
}
