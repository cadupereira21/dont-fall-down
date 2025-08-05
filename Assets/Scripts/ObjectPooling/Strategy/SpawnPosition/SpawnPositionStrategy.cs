using ObjectPooling.Strategy.Attributes;
using UnityEngine;

namespace ObjectPooling.Strategy.SpawnPosition {
    public abstract class SpawnPositionStrategy {

        public abstract void Init(SpawnPositionAttributeSo attributeSo);

        public abstract Vector3 GetPosition();

    }
}