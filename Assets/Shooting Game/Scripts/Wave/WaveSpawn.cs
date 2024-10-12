using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ShootingGame
{
    public class WaveSpawn : MonoBehaviour
    {
        [SerializeField] private List<Transform> listSpawns;
        [SerializeField] private List<WaveData> waves;
        [SerializeField] private int currentWaveIndex;
        [SerializeField] private bool isSpawning;
        [SerializeField] private float delaySpawned;

        [SerializeField] private bool isWon;
        [SerializeField] private Transform enemiesHolder;
        [SerializeField] private int remainingEnemies;


        void Start()
        {
            StartCoroutine(SpawnWave());
        }

        IEnumerator SpawnWave()
        {
            while (currentWaveIndex < waves.Count)
            {
                WaveData currentWave = waves[currentWaveIndex];
                isSpawning = true;

                for (int i = 0; i < currentWave.count; i++)
                {
                    remainingEnemies++;
                    SpawnEnemy(currentWave.enemies);
                    yield return new WaitForSeconds(currentWave.spawnInterval);
                }

                isSpawning = false;
                currentWaveIndex++;
                yield return new WaitForSeconds(delaySpawned); 
            }

            if(remainingEnemies == 0)
            {
                CheckWin();
            }

        }

        public void CheckWin()
        {
            isWon = true;
        }

        public void OnEnemyDestroyed()
        {
            remainingEnemies--;
        }

        void SpawnEnemy(List<GameObject> enemyTypes)
        {
            int randomIndex = UnityEngine.Random.Range(0, enemyTypes.Count);
            GameObject enemyToSpawn = enemyTypes[randomIndex];

            int spawnPointIndex = UnityEngine.Random.Range(0, listSpawns.Count);
            Transform spawnPoint = listSpawns[spawnPointIndex];

            GameObject obj = ObjectPool.Ins.SpawnFromPool(enemyToSpawn.name, spawnPoint.position, Quaternion.identity);
            Enemy enemy = obj.GetComponent<Enemy>();
            enemy.enemyHealth.onDeath.AddListener(OnEnemyDestroyed);
        }
    }
}

