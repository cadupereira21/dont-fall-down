using Game_Scene.ObjectPooling;
using Game_Scene.ObjectPooling.Strategy.Attributes;
using Game_Scene.ObjectPooling.Strategy.SpawnPosition;
using UnityEngine;

namespace Game_Scene.PlayerModifier.Buffs.Spawn {  
    public class BuffSpawnManager : SpawnManager {
        
        private void Start() {
            this.InvokeRepeating(nameof(InstantiatePowerUp), 4, 8);
        }

        private void InstantiatePowerUp() {
            this.SpawnObject(this.GetSpawnPosition());
        }
    }
}