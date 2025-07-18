using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : PlayerInteraction
{

    [SerializeField] private int _attackDamage = 1;

    [SerializeField] private Enemy _enemyAttacked;



    protected override void DoAction(Entity entity)
    {
        Enemy enemy = (Enemy)entity;
        if (!enemy.isDead)
        {
            _enemyAttacked = (Enemy)entity;
            if (_enemyAttacked && !_enemyAttacked.isDead)
                base.DoAction(entity);
        }

    }

    private void Attack()
    {

        if (_enemyAttacked && !_enemyAttacked.isDead)
        {
            _enemyAttacked.TakeDamage(_attackDamage);
        }
    }
}
