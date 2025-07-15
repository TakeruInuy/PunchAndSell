using UnityEngine;

public class Enemy : Entity
{


    [SerializeField] private int _hitPoints = 1;
    public bool isDead = false;

    public void TakeDamage(int damageToTake)
    {
        
        _hitPoints -= damageToTake;
        if (_hitPoints <= 0)
        {
            Die();
        }       
    }

    public void Die()
    {
        if(!isDead)
        {
            isDead = true;
            Debug.Log("I am dead " + gameObject.name);
        }        
    }    
}
