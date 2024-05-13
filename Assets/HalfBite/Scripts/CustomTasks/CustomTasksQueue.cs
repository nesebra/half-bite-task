using System.Collections.Generic;
using System.Linq;
using Logger = HalfBite.Scripts.Tools.Logger;

namespace HalfBite.Scripts.CustomTasks
{
    public class CustomTasksQueue
    {
        private readonly Queue<CustomTask> tasksQueue = new();
        private CustomTask currentTask;
        
        public void Enqueue(CustomTask task)
        {
            tasksQueue.Enqueue(task);
            TryToRunTask();
        }

        private void TryToRunTask()
        {
            if (currentTask != null)
            {
                return;
            }
            
            if (tasksQueue.Any())
            {
                currentTask = tasksQueue.Dequeue();
                currentTask.Started += OnTaskStarted;
                currentTask.Completed += OnTaskCompleted;
                
                currentTask.Start();
            }
        }
        
        private void OnTaskStarted()
        {
            Logger.Log($"task started, tasks in queue - {tasksQueue.Count}", Logger.LoggerAreas.TasksQueueTask);
        }

        private void OnTaskCompleted(CustomTask task, CustomTask.CustomTaskResult result)
        {
            Logger.Log($"task ended, result - {result.Result}, work time - {result.Time}", Logger.LoggerAreas.TasksQueueTask);
            currentTask = null;
            TryToRunTask();
        }
    }
}