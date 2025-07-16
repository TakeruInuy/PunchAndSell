using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerEnemyCollect : PlayerInteraction
{

    public List<Enemy> enemiesCollected;

    [Header("Enemy Collection Attributes")]
    [SerializeField] private float _enemyOnBackDepthOffset = 1f;
    [SerializeField] private float _enemyOnBackHeightOffset = 1f;
    [SerializeField] private int _startingEnemiesCollectedCapacity = 2;
    private Transform _collectedEnemiesFollowTarget;
    [SerializeField] private float _collectedEnemiesBaseFollowSpeed = 20f;
    [SerializeField] private AnimationCurve _collectedEnemyFollowCurve;


    [Header("Upgrades")]
    [HideInInspector] public int maxEnemiesCapacity;
    [SerializeField] private int _upgradeCapacityIncrease = 1;
    [SerializeField] private int _upgradeCost = 1;

    private void Awake()
    {
        GenerateFollowTarget();
    }



    private void Start()
    {
        maxEnemiesCapacity = _startingEnemiesCollectedCapacity;
        enemiesCollected = new List<Enemy>();
    }

    protected override void DoAction(Entity entity)
    {        
        Enemy enemy = (Enemy)entity;
        if(enemy && enemiesCollected.Count < maxEnemiesCapacity && !enemiesCollected.Contains(enemy) && enemy.isDead) 
        {
            //enemy.transform.parent = transform;
            enemiesCollected.Add(enemy);

            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + _enemyOnBackHeightOffset * enemiesCollected.IndexOf(enemy), enemy.transform.position.z);

            enemy.followTarget.EnableFollow(_collectedEnemiesFollowTarget, _collectedEnemiesBaseFollowSpeed * _collectedEnemyFollowCurve.Evaluate(enemiesCollected.IndexOf(enemy) / 100f));


            //for (int i = 0; i < enemiesCollected.Count; i++)
            //{


            //    //var newPos = new Vector3(0, _enemyOnBackHeightOffset * i, -_enemyOnBackDepthOffset);
            //    //enemiesCollected[i].transform.localPosition = newPos;
            //}
            base.DoAction(entity);
        }       
    }

    private void GenerateFollowTarget()
    {
        _collectedEnemiesFollowTarget = new GameObject().transform;
        _collectedEnemiesFollowTarget.parent = transform;
        _collectedEnemiesFollowTarget.name = "Follow Target";
        _collectedEnemiesFollowTarget.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _enemyOnBackDepthOffset);
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

    public void IncreaseCapacity()
    {
        if (ResourceManager.Instance.resource >= _upgradeCost)
        {
            maxEnemiesCapacity += _upgradeCapacityIncrease;
            ResourceManager.Instance.RemoveResource(_upgradeCost);
        }
        
    }
}