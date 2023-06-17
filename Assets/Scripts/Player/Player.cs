using System;
using UnityEngine;

namespace Player
{
    public class Player
    {
        [SerializeField] private int _maxHP;
        [SerializeField] private int _currentHP;

        public Action OnDeath;

        public void GetDamage(int damage)
        {
            _currentHP -= damage;
            if (_currentHP <= 0)
                Die();
        }

        public void GetHeal(int heal)
        {
            _currentHP += heal;
            if (_currentHP > _maxHP)
                _currentHP = _maxHP;
        }

        private void Die()
        {
            OnDeath?.Invoke();
        }
    }
}