using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] private int _hitPoints = 1;
    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
            Debug.Log("I am dead " + gameObject.name);
        }
        
    }


    
}
