using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : PlayerInteraction
{

    [SerializeField] private int _attackDamage = 1;



    protected override void DoAction(Entity entity)
    {
        
        Enemy enemy = (Enemy)entity;
        if (enemy)
        {
            enemy.TakeDamage(_attackDamage);
            base.DoAction(entity);
        }
            

    }

}
