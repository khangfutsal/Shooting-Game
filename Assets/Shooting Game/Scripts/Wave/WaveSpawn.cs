using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ShootingGame
{
    public class WaveSpawn : MonoBehaviour
    {
        [SerializeField] private List<Transform> listSpawns;
        [SerializeField] private List<WaveData> waves;
        [SerializeField] private int currentWaveIndex;
        [SerializeField] private bool isSpawning;
        [SerializeField] private float delaySpawned;

        [SerializeField] private Transform enemiesHolder;
        [SerializeField] private int remainingEnemies;
        public static UnityEvent onWin = new UnityEvent();


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
            StartCoroutine(CheckWin());

        }

        public IEnumerator CheckWin()
        {
            yield return new WaitUntil(() => remainingEnemies == 0);
            UIController.Ins.manager.GetWinUI().Show();
            Debug.Log("WInn");
            onWin?.Invoke();
        }

        public void OnEnemyDestroyed()
        {
            remainingEnemies--;
            Debug.Log("Remain :" + remainingEnemies);
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

