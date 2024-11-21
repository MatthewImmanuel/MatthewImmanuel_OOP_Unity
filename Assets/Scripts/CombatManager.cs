using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    private void Start()
    {
        StartCoroutine(ManageWaves());
    }

    private IEnumerator ManageWaves()
    {
        while (true)
        {
            timer += Time.deltaTime;

            if (timer >= waveInterval)
            {
                timer = 0;
                StartWave();
            }

            yield return null;
        }
    }

    private void StartWave()
    {
        waveNumber++;
        totalEnemies = 0;

        foreach (var spawner in enemySpawners)
        {
            spawner.isSpawning = true;
            spawner.defaultSpawnCount = waveNumber;
            spawner.spawnCountMultiplier = waveNumber;
            totalEnemies += spawner.defaultSpawnCount + spawner.spawnCountMultiplier;
        }
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
        if (totalEnemies <= 0)
        {
            foreach (var spawner in enemySpawners)
            {
                spawner.isSpawning = false;
            }
        }
    }
}
