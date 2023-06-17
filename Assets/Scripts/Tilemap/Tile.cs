using System;
using UnityEngine;

namespace TileMap
{
    public class Tile : MonoBehaviour
    {
        [field: SerializeField] public TileType type { get; private set; }
        //[SerializeField] private Structure _structure;
        [HideInInspector] public Vector2Int gridPosition;
        [SerializeField] private Player.Player player;
        
        private int damage;
        private int heal;
        public Action OnPlayerEnter;

        public Vector2 Position
        {
            get
                => (Vector2) transform.position;
            
            set
                => transform.position = value;
        }

        private void Awake()
        {
            TileGrid.instance.AddTile(this);
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
            player.GetDamage(damage);
        }
        public void GiveHealToPlayer()
        {
            player.GetHeal(heal);
        }
    }
}