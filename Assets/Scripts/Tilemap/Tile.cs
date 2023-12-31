using System;
using UnityEngine;

public enum InfluenceNeighboursType
{
    Moor,
    Neumann,
}
namespace TileMap
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileType _type;
        
        public TileType type
        {
            get => _type;
            private set
            {
                _type = value;
                TypeProcessing();
            }
        }
        public InfluenceNeighboursType _influenceNeighboursType;

        //[SerializeField] private Structure _structure;
        public Vector2Int gridPosition;
        [SerializeField] private Player.Player player;
        
        private int damage;
        private int heal;
        public Action OnPlayerEnter;

        private Tile[] tilesWithInfluence  = new Tile[0];
        public Enemy enemy;

        public Vector2 Position
        {
            get
                => (Vector2) transform.position;
            
            set
                => transform.position = value;
        }

        public void Start()
        {
            TileGrid.instance.AddTile(this);
            TypeProcessing();
        }
        public void SetArgs(TileCreateArgs args)
        {
            type = args.type;
        }


        public void SetDamage(int damage)
        {
            this.damage = damage;
        }
        public void SetHeal(int heal)
        {
            this.heal = heal;
        }

        public void GiveDamageToPlayer()
        {
            player.Damage(damage);
        }
        public void GiveHealToPlayer()
        {
            player.GetHeal(heal);
        }

        private void TypeProcessing()
        {
            foreach (Tile _tile in tilesWithInfluence)
            {
                if(!_tile)
                    continue;
                _tile.OnPlayerEnter = null;
            }
            
            switch (_influenceNeighboursType)
            {
                case InfluenceNeighboursType.Moor:
                    tilesWithInfluence = TileGrid.instance.GetMooreNeighbourTiles(this);
                    break;
                case InfluenceNeighboursType.Neumann:
                    tilesWithInfluence = TileGrid.instance.GetNeumannNeighbourTiles(this);
                    break;
            }
            
            switch (type)
            {
                case TileType.Village:
                    foreach (var _tile in tilesWithInfluence)
                    {
                        if(!_tile)
                            continue;
                        _tile.SetHeal(5);
                        _tile.OnPlayerEnter += _tile.GiveHealToPlayer;
                    }
                    break;
            }
        }

        public void UpdateSurroundings()
        {
            GetComponent<EntitySpawner>()?.UpdateSurroundingRoads();
        }

        private void Update()
        {
            if (!enemy)
            {
                if (GetComponentInChildren<Enemy>())
                {
                    enemy = GetComponentInChildren<Enemy>();
                }
            }
        }
    }
}