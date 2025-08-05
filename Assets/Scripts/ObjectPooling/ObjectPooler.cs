using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling {
    public class ObjectPooler {
        private readonly GameObject _parent;

        private readonly GameObject _object;

        private readonly List<GameObject> _objectPool = new ();
        
        private readonly Queue<int> _inactiveObjects = new ();

        private readonly int _maxSize;
        
        public int CountActive => _objectPool.Count - _inactiveObjects.Count;
        
        public ObjectPooler(GameObject obj, int defaultSize, int maxSize, GameObject parent = null) {
            _object = obj;
            _maxSize = maxSize;
            _parent = parent;
            
            for (int i = 0; i < defaultSize; i++) {
                PoolObject();
            }
        }
        
        public ObjectPoolerDto GetObject(Vector3 position) {
            ObjectPoolerDto dto = GetObject();
            dto.Obj.transform.position = position;
            return dto;
        }
        
        public ObjectPoolerDto GetObject() {
            if (_inactiveObjects.Count == 0) {
                PoolObject();
            }
            
            ObjectPoolerDto dto = GetInactiveObject();
            dto.Obj.gameObject.SetActive(true);
            return dto;
        }

        public void ReleaseObject(int i, bool resetRigidbody = false) {
            _inactiveObjects.Enqueue(i);
            GameObject pooledObject = _objectPool[i];
            pooledObject.SetActive(false);

            if (resetRigidbody) {
                ResetRigidbody(pooledObject);
            }
        }
        
        private void PoolObject() {
            if (_objectPool.Count >= _maxSize) {
                return;
            }
            
            GameObject newObject = Object.Instantiate(_object, _parent?.transform);
            newObject.gameObject.SetActive(false);
            _objectPool.Add(newObject);
            _inactiveObjects.Enqueue(_objectPool.Count - 1);
        }
            
        private ObjectPoolerDto GetInactiveObject() {
            int index = _inactiveObjects.Dequeue();
            return new ObjectPoolerDto(_objectPool[index], index);
        }
        
        private static void ResetRigidbody(GameObject pooledObject) {
            if (!pooledObject.TryGetComponent(out Rigidbody rb)) return;
            
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}