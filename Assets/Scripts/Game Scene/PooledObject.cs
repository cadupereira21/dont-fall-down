using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public abstract class PooledObject : MonoBehaviour {
        protected ObjectPooler _pooler;

        protected int _indexAtPooler;
        
        public void Init(ObjectPooler pooler, int indexAtPooler) {
            _pooler = pooler;
            _indexAtPooler = indexAtPooler;
        }
    }
}
