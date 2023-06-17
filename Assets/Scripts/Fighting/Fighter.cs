using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Fighting fighting;
    public IDamagable damagable;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 enemyPosition;
    private float attackMove;

    public IDamagable target;


    public void AttackCoroutine()
    {
        AttackMove();
        target.Damage(damagable.damage);
    }

    private void AttackMove()
    {
        transform.DOMoveX(transform.parent.position.x + enemyPosition.x, .12f).SetEase(Ease.InElastic).onComplete = MoveBack;
        Debug.Log("start pos " + startPosition.ToString());
        Debug.Log("enemy pos " + enemyPosition.ToString());
        fighting.playerTurn = !fighting.playerTurn;

    }

    private void MoveBack()
        => transform.DOMoveX(transform.parent.position.x + startPosition.x, .12f).SetEase(Ease.InElastic);
}
