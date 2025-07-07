using System;
using System.Collections;
using System.Linq;
using Game_Scene.PlayerModifier.Buffs;
using UnityEngine;

namespace Game_Scene.Player {
    public class PlayerBuffController : MonoBehaviour {
        
        [SerializeField]
        [Tooltip("The prefab of the power up that'll be with the player when they have a power up.")]
        private GameObject buffIndicator;
        
        public Buff ActiveBuff { get; private set; }

        public bool HasBuff => ActiveBuff != null;

        public void SetBuff(GameObject obj) {
            if (obj.TryGetComponent(out Buff buff)) {
                SetBuff(buff);
            } else {
                Debug.LogWarning($"[PlayerBuffController ({DateTime.UtcNow.ToLongTimeString()})] The collided object does not have a buff component: " + obj.name);
            }
        }

        private void SetBuff(Buff buff) {
            this.StopAllCoroutines();
            
            ActiveBuff = buff;
            buffIndicator.SetActive(true);
            
            Debug.Log($"[PlayerBuffController ({DateTime.UtcNow.ToLongTimeString()})] Player collected buff: " + buff.GetType().ToString().Split(".").Last());
            this.StartCoroutine(BuffCountdownRoutine());
        }
        
        private IEnumerator BuffCountdownRoutine() {
            yield return new WaitForSeconds(ActiveBuff.GetDuration);
            
            ActiveBuff = null;
            buffIndicator.SetActive(false);
        }
    }
}