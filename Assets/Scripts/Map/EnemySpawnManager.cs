using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    
    [HideInInspector]
    public float spawnRadius = 15f;
    [HideInInspector]
    public float minDistanceToPlayer = 10f;

    public float spawnTimer = 0f;
    public float spawnInterval = 3f;
    
    public int maxEnemies;

    public Transform player;

    private List<EnemyBase> activeEnemies = new List<EnemyBase>();
    
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>().transform;
    }


    void Update()
    {  
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnInterval /*&& activeEnemies.Count < maxEnemies*/)
        {
            spawnTimer = 0f;
            TrySpawnEnemy();
        }
        activeEnemies.RemoveAll(e => e == null);
    }
    void TrySpawnEnemy()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        Vector2 spawnPosition = (Vector2)player.position + randomDirection * Random.Range(minDistanceToPlayer, spawnRadius);
    }
}
