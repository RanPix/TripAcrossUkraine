using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private int money;
        
        public int damage { get; set; } = 30;
        public int maxHP { get; set; } = 100;
        public int currentHP { get; set; }
        public Action OnDeath { get; set; }
        public float timeBetweenAttacks { get; set; }
        public float lastAttackTime { get; set; }

        [SerializeField] private GameObject fighting;
        private void Start()
        {
            CharacterAndUIConnector.instance.ConnectUI(this);
        }


        public void Damage(int damage)
        {
            currentHP -= damage;
            if (currentHP <= 0)
                Die();
        }

        public void GetHeal(int heal)
        {
            currentHP += heal;
            if (currentHP > maxHP)
                currentHP = maxHP;
        }

        public void Die()
        {
            OnDeath?.Invoke();
        }

        public void Fight(IDamagable enemy)
        {
            Fighting fightingGO = GameObject.Instantiate(fighting, GameObject.FindWithTag("Canvas").transform).GetComponent<Fighting>();
            fightingGO.player.damagable = this;
            fightingGO.enemy.damagable = enemy;
        }
    }
}