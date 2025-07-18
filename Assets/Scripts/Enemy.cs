using UnityEngine;

public class Enemy : Entity
{


    [SerializeField] private int _hitPoints = 1;
    public int resourceDropped = 2;
    public bool isDead = false;
    //[HideInInspector]public FollowTarget followTarget;
    [HideInInspector] public InertiaFollowTarget followTarget;




    private void Awake()
    {
        followTarget = GetComponent<InertiaFollowTarget>();
    }

    private void OnEnable()
    {
        followTarget.DisableFollow();
    }

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
        }        
    }    
}
