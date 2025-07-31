using System.Runtime.CompilerServices;

namespace Logger {
    public interface ILogger {
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        
        void Log(string message, [CallerMemberName] string member = "", [CallerFilePath] string file = "", [CallerLineNumber] int line = 0) {
            UnityEngine.Debug.Log($"[{System.IO.Path.GetFileName(file)}:{line} - {member}] {message}");
        }
    }
}