using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy;
    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 6;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 2;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;
    public bool isSpawning = false;

    private void Start()
    {
        if (isSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            for (int i = 0; i < defaultSpawnCount + spawnCountMultiplier * multiplierIncreaseCount; i++)
            {
                if (spawnedEnemy != null)
                {
                    Instantiate(spawnedEnemy, transform.position, Quaternion.identity);
                    spawnCount++;
                }
            }

            yield return new WaitForSeconds(spawnInterval);

            if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
            {
                spawnCountMultiplier++;
                totalKillWave = 0;
            }
        }
    }

    public void EnemyDefeated()
    {
        totalKill++;
        totalKillWave++;
    }
}
