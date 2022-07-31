using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
        public List<GameObject> enemyPrefabs;
        public List<EnemyConfig> enemyConfigs;
        public Vector3 spawnReferencePosition;
        public int amountToSpawn;
        public Quaternion spawnRotation;
        public float spawnCadence;
        public float initialWaitTime;

        private void Start() {
            StartCoroutine(EnemySpawnCoroutine());
        }

        private IEnumerator EnemySpawnCoroutine ()
        {
            yield return new WaitForSeconds(initialWaitTime);
            for (int i = 0; i < amountToSpawn; i++)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-spawnReferencePosition.x, spawnReferencePosition.x), spawnReferencePosition.y, spawnReferencePosition.z);
                SpawnEnemy(randomPosition, spawnRotation);
                yield return new WaitForSeconds(spawnCadence);
            }
        }

        public void SpawnEnemy(Vector3 enemyPosition, Quaternion rotation)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            var enemyInstance = Instantiate(enemyPrefabs[randomIndex], enemyPosition, rotation);
            var enemyController = enemyInstance.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                int randomConfigIndex = Random.Range(0, enemyConfigs.Count);
                enemyController.config = enemyConfigs[randomConfigIndex];
            }
        }
}
