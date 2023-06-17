using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private string name;
    public int damage { get; set; } = 1;
    public int maxHP { get; set; } = 100;
    public int currentHP { get; set; }
    public Action OnDeath { get; set; }
    public float timeBetweenAttacks { get; set; }
    public float lastAttackTime { get; set; }


    [SerializeField] private Sprite sprite;


    public void Damage(int damage)
    {
        currentHP -= damage;
        if (damage <= 0)
            Die();
    }

    private void Die()
    {
        OnDeath?.Invoke();
    }
}