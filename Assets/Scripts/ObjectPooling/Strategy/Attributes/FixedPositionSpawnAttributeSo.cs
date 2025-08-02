using UnityEngine;

namespace ObjectPooling.Strategy.Attributes {
    [CreateAssetMenu(fileName = "SpawnFixedPositionAttributes", menuName = "Object Pooler Configuration/Spawn Position/Fixed Position", order = 1)]
    public class FixedPositionSpawnAttributeSo : SpawnPositionAttributeSo {

        public Vector3 worldPosition;

    }
}