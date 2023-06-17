using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public IDamagable damagable;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 enemyPosition;

    public IDamagable target;


    public IEnumerator AttackCoroutine()
    {
        transform.DOLocalMoveX(enemyPosition.x, 2);
        yield return new WaitForSeconds(2);
        target.Damage(damagable.damage);
        transform.DOLocalMoveX(startPosition.x, 2);
        yield return new WaitForSeconds(2);
    }
}
