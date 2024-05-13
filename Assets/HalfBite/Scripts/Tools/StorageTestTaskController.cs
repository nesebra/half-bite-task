using System;
using HalfBite.Scripts.Storage;
using Zenject;
using Random = UnityEngine.Random;

namespace HalfBite.Scripts.Tools
{
    public class StorageTestTaskController
    {
        [Inject] private PlayerStorage playerStorage;
        
        public void Run()
        {
            var classToSaveKey = "storage_task_key";

            var classToSave = new StorageTaskExampleClass
            {
                A = Random.Range(0, 100),
                B = Random.Range(0f, 100f),
                C = "storage task"
            };
            
            Logger.Log($"generating class {classToSave}", Logger.LoggerAreas.StorageTask);
            
            playerStorage.Save(classToSaveKey, classToSave);
            Logger.Log($"saving...", Logger.LoggerAreas.StorageTask);
            
            var loadedClass = playerStorage.Load<StorageTaskExampleClass>(classToSaveKey);
            Logger.Log($"loaded class is {loadedClass}", Logger.LoggerAreas.StorageTask);
            
            if (Equals(loadedClass, classToSave))
            {
                Logger.Log($"storage task completed!", Logger.LoggerAreas.StorageTask);
            }
            else
            {
                Logger.Log("some problems with validation... loaded and saved class are not similar",
                    Logger.LoggerAreas.StorageTask, Logger.LoggerTypes.Error);
            }
        }

        private class StorageTaskExampleClass
        {
            public int A;
            public float B;
            public string C;

            public override string ToString()
            {
                return $"[A={A}, B={B}, C={C}]";
            }

            private bool Equals(StorageTaskExampleClass other)
            {
                return A == other.A && B.Equals(other.B) && C == other.C;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != GetType()) return false;
                return Equals((StorageTaskExampleClass) obj);
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(A, B, C);
            }
        }
        
    }
}