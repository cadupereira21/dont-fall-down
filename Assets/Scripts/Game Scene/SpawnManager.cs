using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts.Game_Scene {
    [RequireComponent(typeof(ObjectPooler))]
    public class SpawnManager : MonoBehaviour {
        [SerializeField] private float spawnRange;

        [SerializeField] private GameObject powerUpPrefab;

        [SerializeField] private GameObject player;

        [SerializeField] private TextMeshProUGUI waveText;
        
        private ObjectPooler _objectPooler;

        private int _wave = 1;

        private readonly List<GameObject> _enemiesAlive = new();

        private void Start() {
            _objectPooler = this.GetComponent<ObjectPooler>();
            this.InvokeRepeating(nameof(InstantiatePowerUp), 4, 8);
            SpawnEnemyWave(_wave++);
        }

        private void Update() {
            if (_enemiesAlive.Count == 0)
                SpawnEnemyWave(_wave++);
        }

        private void LateUpdate() {
            foreach (GameObject enemy in _enemiesAlive.ToList().Where(enemy => enemy.activeSelf == false)) {
                _enemiesAlive.Remove(enemy);
            }
        }

        private void SpawnEnemyWave(int enemyCount) {
            if (_objectPooler.poolSize < enemyCount) {
                _objectPooler.PoolNewObject();
            }
            
            for (int i = 0; i < enemyCount; i++) {
                ActivateEnemyFromObjectPooler();
                waveText.text = $"Wave: {enemyCount}";
            }
        }

        private void ActivateEnemyFromObjectPooler() {
            ObjectPoolerDto objectPoolerDto = _objectPooler.ActivateObjectAtPosition(GenerateSpawnPosition());
            if (objectPoolerDto.gameObject.TryGetComponent(out EnemyController enemyController)) {
                enemyController.Init(player, _objectPooler, objectPoolerDto.indexAtPooler);
            }

            _enemiesAlive.Add(objectPoolerDto.gameObject);
        }

        private void InstantiatePowerUp() {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        }

        private Vector3 GenerateSpawnPosition() {
            float randomPositionX = Random.Range(-spawnRange, spawnRange);
            float randomPositionZ = Random.Range(-spawnRange, spawnRange);
            return new Vector3(randomPositionX, 0, randomPositionZ);
        }
    }
}