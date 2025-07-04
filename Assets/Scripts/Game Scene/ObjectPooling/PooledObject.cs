using UnityEngine;

namespace Game_Scene.ObjectPooling {
    public abstract class PooledObject : MonoBehaviour {
    
        protected SpawnManager SpawnManager;
        
        protected int IndexAtPooler;
        
        public void Init(SpawnManager spawnManager, int indexAtPooler) {
            SpawnManager = spawnManager;
            IndexAtPooler = indexAtPooler;
        }
    }
}