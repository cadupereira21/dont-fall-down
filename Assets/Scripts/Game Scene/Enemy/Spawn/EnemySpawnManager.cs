﻿using Game_Scene.ObjectPooling;
using Game_Scene.ObjectPooling.Strategy.Attributes;
using Game_Scene.ObjectPooling.Strategy.SpawnPosition;
using UnityEngine;
using UnityEngine.Events;

namespace Game_Scene.Enemy.Spawn {
    public class EnemySpawnManager : SpawnManager {
        
        [Header("Enemy Settings")] 
        [SerializeField]
        private GameObject player;

        private int _wave = 1;
        
        public static readonly UnityEvent<int> OnNewWaveSpawned = new ();

        private void Start() {
            SpawnEnemyWave(_wave);
        }
        
        private void Update() {
            if (this.CountActive > 0) return;
            
            SpawnEnemyWave(++_wave);
        }
        
        private void SpawnEnemyWave(int enemyCount) {
            OnNewWaveSpawned.Invoke(enemyCount);
            for (int i = 0; i < enemyCount; i++) {
                SpawnEnemy();
            }
        }
        
        private void SpawnEnemy() {
            ObjectPoolerDto objectPoolerDto = this.SpawnObject();
            
            if (!objectPoolerDto.Obj.TryGetComponent(out Enemy enemyController)) return;
            
            enemyController.Init(player, this, objectPoolerDto.IndexAtPooler);
            enemyController.transform.position = this.GetSpawnPosition();
        }
    }
}