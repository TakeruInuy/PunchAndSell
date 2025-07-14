using UnityEngine;

public abstract class PlayerEnemyInteraction : MonoBehaviour
{

    [SerializeField] protected float _actionRadius = 5f;
    [SerializeField] protected LayerMask _enemyLayer;
    [SerializeField] protected Transform radiusUI;
    [SerializeField] protected float _UIScaleMultiplier = 1;



    // Update is called once per frame
    void Update()
    {
        CheckForEnemy();
    }

    protected void CheckForEnemy()
    {
        var enemiesHit = Physics.OverlapSphere(transform.position, _actionRadius, _enemyLayer);

        foreach (var enemy in enemiesHit)
        {
            var enemyComponent = enemy.GetComponent<Enemy>();
            DoAction(enemyComponent);
        }
    }

    protected abstract void DoAction(Enemy enemy);


    protected virtual void OnValidate()
    {
        if (radiusUI != null)
        {
            radiusUI.localScale = new Vector3(_actionRadius * _UIScaleMultiplier, _actionRadius * _UIScaleMultiplier, _actionRadius * _UIScaleMultiplier);
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Color gizmosColor = Color.yellow;
        gizmosColor.a = 0.3f;

        Gizmos.color = gizmosColor;
        
        Gizmos.DrawSphere(transform.position, _actionRadius);
    }


}
