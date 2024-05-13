using System;
using DG.Tweening;

namespace HalfBite.Scripts.CustomTasks
{
    public class CustomTask
    {
        public event Action Started;
        public event Action<CustomTask, CustomTaskResult> Completed;

        private readonly Action taskAction;

        public CustomTask(Action taskAction)
        {
            this.taskAction = taskAction;
        }
        
        public void Start()
        {
            Started?.Invoke();
            taskAction();
            Complete();
        }

        private void Complete()
        {
            //simulating work time
            var workTime = UnityEngine.Random.Range(3f, 7f);
   
            DOVirtual.DelayedCall(workTime, () =>
            {
                Completed?.Invoke(this, new CustomTaskResult
                {
                    Time = workTime,
                    Result = true
                });
            });
        }
        
        public class CustomTaskResult
        {
            public float Time;
            public bool Result;
        }
    }
}