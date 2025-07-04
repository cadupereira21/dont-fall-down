using Game_Scene.ObjectPooling.Strategy.Attributes;
using UnityEngine;

namespace Game_Scene.ObjectPooling.Strategy.SpawnPosition {
    public abstract class SpawnPositionStrategy {

        public abstract void Init(SpawnPositionAttributeSo attributeSo);

        public abstract Vector3 GetPosition();

    }
}