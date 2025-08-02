using System;
using ObjectPooling.Strategy.Attributes;
using UnityEngine;

namespace ObjectPooling.Strategy.SpawnPosition {
    public class FixedPositionSpawnStrategy : SpawnPositionStrategy {

        private Vector3 _spawnPosition;
        
        public override void Init(SpawnPositionAttributeSo attributeSo) {
            if (attributeSo.GetType() != typeof(FixedPositionSpawnAttributeSo)) {
                throw new InvalidCastException($"Arguments provided for FixedPositionSpawnStrategy must be of type FixedPositionSpawnAttributeSo. Provided type is '{attributeSo.GetType()}'");
            }
        
            FixedPositionSpawnAttributeSo timerAttributesSo = (FixedPositionSpawnAttributeSo) attributeSo;
            
            _spawnPosition = timerAttributesSo.worldPosition;
        }
        
        public override Vector3 GetPosition() => _spawnPosition;
        
    }
}