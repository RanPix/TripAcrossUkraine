using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public Fighter player;
    public Fighter enemy;

    public bool smbDead;
    public bool playerTurn = true;
    
    // Start is called before the first frame update
    void Start()
    {
        player.fighting = this;
        enemy.fighting = this;
        player.target = enemy.damagable;
        enemy.target = player.damagable;    
        player.damagable.OnDeath += () => smbDead = true;
        enemy.damagable.OnDeath += () => smbDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Shot());
        if(smbDead)
            Destroy(this);
    }

    private IEnumerator Shot()
    {
        player.AttackCoroutine();
        yield return new WaitForSeconds(.25f);
        enemy.AttackCoroutine();
        yield return new WaitForSeconds(.25f);
    }   
}
