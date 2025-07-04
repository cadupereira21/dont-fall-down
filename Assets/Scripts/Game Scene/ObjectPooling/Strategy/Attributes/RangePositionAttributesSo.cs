using UnityEngine;

namespace Game_Scene.ObjectPooling.Strategy.Attributes {
    [CreateAssetMenu(fileName = "RangePositionAttributes", menuName = "Object Pooler Configuration/Spawn Position/Range Position")]
    public class RangePositionAttributesSo : SpawnPositionAttributeSo {
        
        public Vector3 minPosition;
        
        public Vector3 maxPosition;
        
    }
}