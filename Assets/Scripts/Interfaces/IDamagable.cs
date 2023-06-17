using System;

public interface IDamagable
{
    public int damage { get; set; }
    public int maxHP { get; set; }
    public int currentHP { get; set; }
    public Action OnDeath { get; set; }
    public float timeBetweenAttacks { get; set; }
    public float lastAttackTime { get; set; }
    public void Damage(int damage);
}