using UnityEngine;

namespace ObjectPooling {
    public abstract class PooledObject : MonoBehaviour {
    
        protected SpawnManager SpawnManager;
        
        protected int IndexAtPooler;
        
        public void Init(SpawnManager spawnManager, int indexAtPooler) {
            SpawnManager = spawnManager;
            IndexAtPooler = indexAtPooler;
        }

        protected void Despawn() {
            SpawnManager.DespawnObject(IndexAtPooler);
        }
    }
}