using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : MonoBehaviour
{
    public Fighting fighting;
    public IDamagable damagable;

    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 enemyPosition;

    public Sprite sprite;

    public IDamagable target;

    private void Start()
    {
        startPosition = transform.position;
        GetComponent<RawImage>().texture = sprite.texture;
    }

    public void Attack(Vector2 enemyPosition)
    {
        this.enemyPosition = enemyPosition;

        StartCoroutine(AttackMove());
        
    }

    private IEnumerator AttackMove()
    {
        transform.DOMoveX(enemyPosition.x, .09f);
        yield return new WaitForSeconds(.091f);

        target.Damage(damagable.damage);
        transform.DOMoveX(startPosition.x, .09f);
    }
}
