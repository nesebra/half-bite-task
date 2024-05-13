using HalfBite.Scripts.Storage;
using HalfBite.Scripts.Tools;
using HalfBite.Scripts.UI;
using UnityEngine;
using Zenject;

namespace HalfBite.Scripts.Core.Launchers
{
    public class GameLauncher : MonoBehaviour
    {
        [Inject] private PlayerStorage playerStorage;
        [Inject] private UiController uiController;
        [Inject] private StorageTestTaskController storageTestTaskController;
        [Inject] private TasksQueueTestTaskController tasksQueueTestTaskController;
        
        private void Awake()
        {
            InitializeAll();
        }

        private void Start()
        {
            storageTestTaskController.Run();
            tasksQueueTestTaskController.Run();
        }

        //todo: bad use case of zenject initialization process, was made for a quick prototyping
        private void InitializeAll()
        {
            playerStorage.Initialize();
            uiController.Initialize();
        }
    }
}