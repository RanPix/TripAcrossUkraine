using UnityEngine;
using UnityEngine.Tilemaps;

public struct TileData
{
    public int damage;

    public TileData(int damage)
    {
        TileTypes type = TileTypes.None;

        this.damage = damage;
    }
}
