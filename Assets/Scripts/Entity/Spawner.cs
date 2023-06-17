using System;
using System.Collections.Generic;
using TileMap;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private Tile parentTile;
    private Dictionary<EntityType, int> spawnerDatas = new();
    private Tile[] currentNeighbours;

    private void Start()
    {
        parentTile = GetComponent<Tile>();
        UpdateSpawnerData();
        Spawn();
    }

    public void Spawn()
    {
        List<Tile> roads = new();

        foreach (Tile tile in currentNeighbours)
        {
            if (tile == null)
                continue;

            if (tile.type == TileType.Road)
                roads.Add(tile);
        }

        foreach (KeyValuePair<EntityType, int> entity in spawnerDatas)
        {
            if (entity.Value > 0)
            {
                Instantiate(enemyPrefab, parentTile.transform).GetComponent<RandomMove>().tile = parentTile;
            }
        }
    }

    public void UpdateSpawnerData()
    {
        spawnerDatas.Clear();
        print(parentTile + "    asdsadasda");
        currentNeighbours = TileGrid.instance.GetMooreNeighbourTiles(parentTile);

        foreach (Tile tile in currentNeighbours)
        {
            if (tile == null)
                continue;

            switch (tile.type)
            {
                case TileType.Forest:
                    if (!spawnerDatas.ContainsKey(EntityType.Wolf))
                    {
                        print("Foreest");
                        spawnerDatas.Add(EntityType.Wolf, 1);
                    }

                    else
                        spawnerDatas[EntityType.Wolf]++;
                    break;

                default:
                    break;
            }
        }
    }
}
