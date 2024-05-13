using HalfBite.Scripts.CustomTasks;
using Zenject;

namespace HalfBite.Scripts.Tools
{
    public class TasksQueueTestTaskController
    {
        [Inject] private CustomTasksQueue tasksQueue;
        
        public void Run()
        {
            tasksQueue.Enqueue(new CustomTask(() =>
            {
                Logger.Log("doing some hard computing task...", Logger.LoggerAreas.TasksQueueTask);
            }));   
            
            tasksQueue.Enqueue(new CustomTask(() =>
            {
                Logger.Log("doing some rendering hard work...", Logger.LoggerAreas.TasksQueueTask);
            }));    
            
            tasksQueue.Enqueue(new CustomTask(() =>
            {
                Logger.Log("drinking coffee :)", Logger.LoggerAreas.TasksQueueTask);
            }));
                        
            tasksQueue.Enqueue(new CustomTask(() =>
            {
                Logger.Log("and again some hardly understandable work...", Logger.LoggerAreas.TasksQueueTask);
            }));         
            
            tasksQueue.Enqueue(new CustomTask(() =>
            {
                Logger.Log("pretending that we did this too to get more money from the client...", Logger.LoggerAreas.TasksQueueTask);
            }));
        }

    }
}