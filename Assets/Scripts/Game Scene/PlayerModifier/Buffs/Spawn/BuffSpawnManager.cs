using Game_Scene.ObjectPooling;
using Game_Scene.ObjectPooling.Strategy.Attributes;
using Game_Scene.ObjectPooling.Strategy.SpawnPosition;
using UnityEngine;

namespace Game_Scene.PlayerModifier.Buffs.Spawn {  
    public class BuffSpawnManager : SpawnManager {
        [Header("Spawn Settings")]
        [SerializeField] 
        private SpawnPosition spawnPosition;
        
        [SerializeField]
        private SpawnPositionAttributeSo spawnPositionAttributes;
        
        private SpawnPositionStrategy _spawnPositionStrategy;
        
        private new void Awake() {
            _spawnPositionStrategy = SpawnPositionStrategyFactory.GetStrategy(spawnPosition, spawnPositionAttributes);
            base.Awake();
        }

        private void Start() {
            this.InvokeRepeating(nameof(InstantiatePowerUp), 4, 8);
        }

        private void InstantiatePowerUp() {
            this.SpawnObject(_spawnPositionStrategy.GetPosition());
        }
    }
}