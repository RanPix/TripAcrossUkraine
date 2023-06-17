using System;
using System.Collections.Generic;
using TileMap;
using UnityEngine;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private EntityType entityType;
    [SerializeField] private GameObject[] enemiesPrefabs;

    private Dictionary<Tile, GameObject> enemies = new();
    private Tile tile;
    private int turnsToSpawn = 5;
    private List<int> deletedEnemies = new ();
    private Dictionary<Tile, int> deletedEnemiess = new();


    private void Awake()
    {
        tile = GetComponent<Tile>();
    }

    private void Start()
    {
        UpdateSurroundingRoads();
        TurnManager.instance.OnNextTurn += SubtractMoves;
    }
    private void Update()
    {
        AddToSpawn();
    }

    private void AddToSpawn()
    {
        int i = 0;
        foreach (var enemy in enemies.Values)
        {
            if (enemy)
                continue;
           Tile __tile = 
            deletedEnemiess.Add();
            
            deletedEnemies.Add(turnsToSpawn);
            i++;
        }
    }

    private void SubtractMoves()
    {
        for(int i = 0; i < deletedEnemies.Count; i++)
        {
            deletedEnemies[i]--;
            if (deletedEnemies[i] == 0)
            {
                deletedEnemies.Remove(deletedEnemies[i]);
                SetEmptyTiles();
            }
        }
    }
    private void SetEmptyTiles()
    {
        foreach (var _tile in enemies.Keys)
        {
            if (!_tile)
                continue;

            if (enemies[_tile])
                continue;

            var enemy = Instantiate(enemiesPrefabs[(int)Random.Range(0, enemiesPrefabs.Length - 0.0001f)], _tile.gameObject.transform);
            enemy.GetComponent<RandomMove>().tile = _tile;

            return;
        }
    }

    public void UpdateSurroundingRoads()
    {
        Dictionary<Tile, GameObject> roadList = new();

        foreach(Tile _tile in TileGrid.instance.GetMooreNeighbourTiles(tile))
        {
            if (!_tile)
                continue;

            if (_tile.type != TileType.Road)
                continue;

            roadList.Add(_tile, null);

            if (enemies.ContainsKey(_tile))
                roadList[_tile] = enemies[_tile];
        }

        enemies = roadList;
    }
}
