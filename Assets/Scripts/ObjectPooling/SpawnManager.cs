using ObjectPooling.Strategy.Attributes;
using ObjectPooling.Strategy.SpawnPosition;
using UnityEngine;

namespace ObjectPooling {
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
        
        [Header("Spawn Settings")]
        [SerializeField] 
        private SpawnPosition spawnPosition;
        
        [SerializeField]
        private SpawnPositionAttributeSo spawnPositionAttributes;
        
        private SpawnPositionStrategy _spawnPositionStrategy;
        
        private ObjectPooler _objectPooler;
        
        protected int CountActive => _objectPooler.CountActive;

        protected void Awake() {
            _spawnPositionStrategy = SpawnPositionStrategyFactory.GetStrategy(spawnPosition, spawnPositionAttributes);
            _objectPooler = new ObjectPooler(prefab, defaultSize, maxSize, this.gameObject);
        }

        protected Vector3 GetSpawnPosition() {
            return _spawnPositionStrategy.GetPosition();
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