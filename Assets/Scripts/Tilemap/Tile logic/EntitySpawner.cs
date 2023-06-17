using System;
using System.Collections.Generic;
using System.Linq;
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
    //private List<int> deletedEnemies = new ();
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
        for (int i = 0; i < enemies.Values.Count; i++)
        {
            if (enemies.Values.ToArray().GetValue(i) != null)
                continue;
            
            Tile __tile = enemies.Keys.ToArray()[i];
            if(!deletedEnemiess.ContainsKey(__tile))
                deletedEnemiess.Add(__tile, turnsToSpawn);
            
        }
    }

    private void SubtractMoves()
    {
        for(int i = 0; i < deletedEnemiess.Count; i++)
        {
            deletedEnemiess[deletedEnemiess.Keys.ToArray()[i]]--;
            if (deletedEnemiess[deletedEnemiess.Keys.ToArray()[i]] == 0)
            {
                deletedEnemiess.Remove(deletedEnemiess.Keys.ToArray()[i]);
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
            enemies[_tile] = enemy;

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
