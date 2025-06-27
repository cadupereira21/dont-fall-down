using UnityEngine;

namespace Course_Library.Scripts.Game_Scene {
    public class ObjectPoolerDto {
        public GameObject gameObject { get; private set; }
        public int indexAtPooler { get; private set; }
        
        public ObjectPoolerDto(GameObject gameObject, int indexAtPooler) {
            this.gameObject = gameObject;
            this.indexAtPooler = indexAtPooler;
        }
    }
}
