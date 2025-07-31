using UnityEngine;

namespace Logger {
    public class UnityLogger : ILogger {
        public void Info(string message) {
            Debug.Log($"{message}");
        }
        public void Warning(string message) {
            Debug.LogWarning($"{message}");
        }
        public void Error(string message) {
            Debug.LogError($"{message}");
        }
    }
}