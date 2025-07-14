using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : PlayerInteraction
{

    [SerializeField] private int _attackDamage = 1;



    protected override void DoAction(Enemy enemy)
    {
        enemy.TakeDamage(_attackDamage);
    }

}
