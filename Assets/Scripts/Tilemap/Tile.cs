using UnityEngine;

namespace TileMap
{
    public class Tile : MonoBehaviour
    {
        public TileType type { get; private set; }
        //[SerializeField] private Structure _structure;
        public Vector2Int gridPosition;
        public Vector2 Position
        {
            get
                => (Vector2) this.transform.position;
            
            set
                => this.transform.position = value;
        }

        private void Awake()
        {
            TileGrid.instance.AddTile(this);
        }
    }
}