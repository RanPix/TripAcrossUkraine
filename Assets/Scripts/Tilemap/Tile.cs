using UnityEngine;

namespace TileMap
{
    public class Tile : MonoBehaviour
    {
        [field: SerializeField] public TileType type { get; private set; }
        //[SerializeField] private Structure _structure;
        [HideInInspector] public Vector2Int gridPosition;

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
    }
}