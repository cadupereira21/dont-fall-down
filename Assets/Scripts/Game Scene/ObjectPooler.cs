using System.Collections.Generic;
using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class ObjectPooler : MonoBehaviour {
        [SerializeField] private GameObject prefab;

        [SerializeField] private int initialPoolSize;
        
        private readonly List<GameObject> _pool = new();
        
        private readonly Queue<int> _inactiveObjects = new();
        
        public int poolSize => _pool.Count;

        private void Start() {
            for (int i = 0; i < initialPoolSize; i++) {
                PoolNewObject();
            }
        }

        private ObjectPoolerDto GetInactiveObjectFromPool() {
            int index = _inactiveObjects.Dequeue();
            return new ObjectPoolerDto(_pool[index], index);
        }

        public void PoolNewObject() {
            GameObject obj = Instantiate(prefab);
            _pool.Add(obj);
            obj.SetActive(false);
            _inactiveObjects.Enqueue(_pool.Count-1);
        }

        public ObjectPoolerDto ActivateObjectAtPosition(Vector3 position) {
            ObjectPoolerDto dto = GetInactiveObjectFromPool();
            dto.gameObject.transform.position = position;
            dto.gameObject.SetActive(true);
            return dto;
        }

        public ObjectPoolerDto ActivateObject() {
            ObjectPoolerDto dto = GetInactiveObjectFromPool();
            dto.gameObject.SetActive(true);
            return dto;
        }

        public void InactivateObject(int i) {
            _inactiveObjects.Enqueue(i);
            _pool[i].SetActive(false);
        }
    }
}