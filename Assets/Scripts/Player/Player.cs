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

        [SerializeField] private Sprite sprite;

        private void Start()
        {
            CharacterAndUIConnector.instance.ConnectUI(this);
            sprite = GetComponent<SpriteRenderer>().sprite;
            currentHP = maxHP;
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
            GameManager.instance.GameOver();
        }

        public void Fight(Enemy enemy)
        {
            Fighting fightingGO = Instantiate(fighting, GameObject.FindWithTag("Canvas").transform).GetComponent<Fighting>();
            fightingGO.player.damagable = this;
            fightingGO.player.sprite = sprite;
            fightingGO.enemy.damagable = enemy;
            fightingGO.enemy.sprite = enemy.GetComponent<Enemy>().sprite;
        }
    }
}