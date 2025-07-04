using Game_Scene.ObjectPooling.Strategy.Attributes;
using UnityEngine;

namespace Game_Scene.ObjectPooling.Strategy.SpawnPosition {
    public class RangePositionSpawnStrategy : SpawnPositionStrategy {

        private Vector3 _minPosition;

        private Vector3 _maxPosition;
        
        public override void Init(SpawnPositionAttributeSo attributeSo) {
            if (attributeSo is not RangePositionAttributesSo rangePositionAttributes) {
                throw new System.ArgumentException("Attribute must be of type RangePositionAttributesSo");
            }

            _minPosition = rangePositionAttributes.minPosition;
            _maxPosition = rangePositionAttributes.maxPosition;
        }

        public override Vector3 GetPosition() {
            float positionX = Random.Range(_minPosition.x, _maxPosition.x);
            float positionY = Random.Range(_minPosition.y, _maxPosition.y);
            float positionZ = Random.Range(_minPosition.z, _maxPosition.z);
            
            return new Vector3(positionX, positionY, positionZ);
        }
    }
}