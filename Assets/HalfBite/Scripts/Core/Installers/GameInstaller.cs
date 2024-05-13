using HalfBite.Scripts.CustomTasks;
using HalfBite.Scripts.Storage;
using HalfBite.Scripts.Tools;
using HalfBite.Scripts.UI;
using HalfBite.Scripts.UI.Other;
using UnityEngine;
using Zenject;

namespace HalfBite.Scripts.Core.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private UiCanvas uiCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<MonoBehaviourHelper>().FromNewComponentOnNewGameObject().AsSingle();
            
            Container.Bind<AddressableController>().AsSingle();
            
            Container.Bind<CustomTasksQueue>().AsSingle();
            Container.Bind<TasksQueueTestTaskController>().AsSingle();
            
            Container.Bind<PlayerStorage>().AsSingle();
            Container.Bind<StorageTestTaskController>().AsSingle();
            
            Container.Bind<UiController>().AsSingle();
            Container.Bind<UiCanvas>().FromInstance(uiCanvas);
        }
    }
}