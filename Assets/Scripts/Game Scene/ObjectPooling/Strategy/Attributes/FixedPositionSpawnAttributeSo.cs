using UnityEngine;

namespace Game_Scene.ObjectPooling.Strategy.Attributes {
    [CreateAssetMenu(fileName = "SpawnFixedPositionAttributes", menuName = "Object Pooler Configuration/Spawn Position/Fixed Position", order = 1)]
    public class FixedPositionSpawnAttributeSo : SpawnPositionAttributeSo {

        public Vector3 worldPosition;

    }
}