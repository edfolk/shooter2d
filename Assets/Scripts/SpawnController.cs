using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
        public GameObject enemyPrefab;

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
            Instantiate(enemyPrefab, enemyPosition, rotation);
        }
}
