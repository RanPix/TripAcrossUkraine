using UnityEngine;

namespace TileMap
{
    public class Tile : MonoBehaviour
    {
        public TileType type;
        //[SerializeField] private Structure _structure;
        public Vector2Int gridPosition;
        public Vector2 globalPosition;

        private void Start()
        {
            TileGrid.instance.AddTile(this);
        }
    }
}