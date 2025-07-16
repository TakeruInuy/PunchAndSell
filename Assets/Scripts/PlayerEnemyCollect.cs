using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerEnemyCollect : PlayerInteraction
{

    public List<Enemy> enemiesCollected;

    [Header("Enemy Collection Attributes")]
    [SerializeField] private float enemyOnBackDepthOffset = 1f;
    [SerializeField] private float enemyOnBackHeightOffset = 1f;
    [SerializeField] private int startingEnemiesCollectedCapacity = 2;
    [HideInInspector] public int maxEnemiesCapacity;


    private void Start()
    {
        maxEnemiesCapacity = startingEnemiesCollectedCapacity;
        enemiesCollected = new List<Enemy>();
    }

    protected override void DoAction(Entity entity)
    {        
        Enemy enemy = (Enemy)entity;
        if(enemy && enemiesCollected.Count < maxEnemiesCapacity && !enemiesCollected.Contains(enemy) && enemy.isDead) 
        {
            enemy.transform.parent = transform;
            enemiesCollected.Add(enemy);
            for (int i = 0; i < enemiesCollected.Count; i++)
            {
                var newPos = new Vector3(0, enemyOnBackHeightOffset * i, -enemyOnBackDepthOffset);
                enemiesCollected[i].transform.localPosition = newPos;
            }
            base.DoAction(entity);
        }       
    }

    public void ClearEnemies()
    {
        foreach (var enemy in enemiesCollected)
        {
            enemy.transform.parent = null;
            enemy.gameObject.SetActive(false);
        }
        int enemiesCleared = enemiesCollected.Count;
        ResourceManager.Instance.AddResource(enemiesCleared);
        enemiesCollected.Clear();        
    }
}