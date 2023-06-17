using System.Threading.Tasks;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public Fighter player;
    public Fighter enemy;

    public bool smbDead;

    private void Start()
    {
        player.fighting = this;
        enemy.fighting = this;
        player.target = enemy.damagable;
        enemy.target = player.damagable;    
        player.damagable.OnDeath += () => smbDead = true;
        enemy.damagable.OnDeath += () => smbDead = true;

        Shot();
    }

    private void Update()
    {
        if (smbDead)
            Destroy(gameObject);
    }

    private async void Shot()
    {
        while (player.damagable.currentHP > 0 && enemy.damagable.currentHP > 0)
        {
            player.Attack(enemy.gameObject.transform.position);
            await Task.Delay(600);

            if (smbDead)
                return;


            enemy.Attack(player.gameObject.transform.position);
            await Task.Delay(600);

            if (smbDead)
                return;
        }
    }   
}
