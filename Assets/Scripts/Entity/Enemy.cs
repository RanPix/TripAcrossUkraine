using TileMap;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private string name;
    [SerializeField] private int damage;
    [SerializeField] private int hp;

    [SerializeField] private Sprite sprite;
    private Tile parentTile;
    private Tile roadTile;

    private void Awake()
    {
        parentTile.GetComponent<EntitySpawner>();
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (damage <= 0)
            Die();
    }

    private void Die()
    {
    }
}