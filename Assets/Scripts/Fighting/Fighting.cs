using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public Fighter player;
    public Fighter enemy;

    public bool smbDead;
    
    // Start is called before the first frame update
    void Start()
    {
        player.target = enemy.damagable;
        enemy.target = player.damagable;    
        player.damagable.OnDeath += () => smbDead = true;
        enemy.damagable.OnDeath += () => smbDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(player.AttackCoroutine());
        StartCoroutine(enemy.AttackCoroutine());
        if(smbDead)
            Destroy(this);
    }
}
