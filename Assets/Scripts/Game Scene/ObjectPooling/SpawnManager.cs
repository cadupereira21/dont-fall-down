using UnityEngine;

namespace Game_Scene.ObjectPooling {
    public abstract class SpawnManager : MonoBehaviour {
        [Header("Object Pooler Attributes")]
        [Tooltip("Prefab to be instantiated by the pooler. \n" +
                 "This should be a GameObject that you want to pool.")]
        [SerializeField]
        protected GameObject prefab;
            
        [Tooltip("Default size of the pool. \n" +
                 "This is the number of objects that will be created when the pool is initialized.")]
        [SerializeField]
        protected int defaultSize;
            
        [Tooltip("Maximum size of the pool. \n" +
                 "This is the maximum number of objects that can be in the pool at any time.")]
        [SerializeField]
        protected int maxSize;
        
        private ObjectPooler _objectPooler;
        
        protected int CountActive => _objectPooler.CountActive;

        protected void Awake() {
            _objectPooler = new ObjectPooler(prefab, defaultSize, maxSize, this.gameObject);
        }

        protected void SpawnObject(Vector3 position) {
            ObjectPoolerDto dto = _objectPooler.GetObject(position);
            if (dto.Obj.TryGetComponent(out PooledObject pooledObject)) {
                pooledObject.Init(this, dto.IndexAtPooler);
            }
        }

        protected ObjectPoolerDto SpawnObject() {
            return _objectPooler.GetObject();
        }

        public void DespawnObject(int index) {
            _objectPooler.ReleaseObject(index, resetRigidbody: true);
        }
    }
}