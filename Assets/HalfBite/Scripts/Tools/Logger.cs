using UnityEngine;

namespace HalfBite.Scripts.Tools
{
    public static class Logger
    {
        public static void Log(string log, LoggerAreas loggerArea = LoggerAreas.Other, LoggerTypes loggerTypes = LoggerTypes.Log)
        {
            var formattedLog = $"[{loggerArea}] {log}";
            
            if (loggerTypes == LoggerTypes.Error)
            {
                Debug.LogError(formattedLog);
            }
            else
            {
                Debug.Log(formattedLog);
            }
        }
        
        public enum LoggerAreas
        {
            Other,
            Core,
            StorageTask,
            TasksQueueTask
        }        
        
        public enum LoggerTypes
        {
            Log,
            Error
        }
    }
}