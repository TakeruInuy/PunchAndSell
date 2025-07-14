using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemyCollectAndDump : PlayerEnemyInteraction
{

    private List<Enemy> enemiesCollected;

    [Header("Enemy Collection Attributes")]
    [SerializeField] private float enemyOnBackDepthOffset = 1f;
    [SerializeField] private float enemyOnBackHeightOffset = 1f;
    [SerializeField] public int startingEnemiesCollectedCapacity = 2;
    private int maxEnemiesCapacity;


    private void Start()
    {
        maxEnemiesCapacity = startingEnemiesCollectedCapacity;
        enemiesCollected = new List<Enemy>();
    }

    protected override void DoAction(Enemy enemy)
    {
        if(enemiesCollected.Count < maxEnemiesCapacity) 
        {
            if (!enemiesCollected.Contains(enemy))
            {
                if (enemy.isDead)
                {
                    enemy.transform.parent = transform;
                    enemiesCollected.Add(enemy);
                    for (int i = 0; i < enemiesCollected.Count; i++)
                    {
                        var newPos = new Vector3(0, enemyOnBackHeightOffset * i, -enemyOnBackDepthOffset);
                        enemiesCollected[i].transform.localPosition = newPos;
                    }
                }
            }
        }
       
       
       
    }


}
