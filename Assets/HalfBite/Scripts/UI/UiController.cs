using System;
using System.Collections.Generic;
using System.Linq;
using HalfBite.Scripts.Core;
using HalfBite.Scripts.UI.Controllers;
using HalfBite.Scripts.UI.Models;
using HalfBite.Scripts.UI.Other;
using HalfBite.Scripts.UI.Views;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace HalfBite.Scripts.UI
{
    public class UiController : IInitializable
    {
        [Inject] private UiCanvas uiCanvas;
        [Inject] private AddressableController addressableController;
        [Inject] private DiContainer diContainer;

        public int PopUpsOpenedCount => openedScreens.Count(screen => screen.IsPopUp);
        public bool IsPopUpFromQueueCanBeOpened => PopUpsOpenedCount == 0;

        private Dictionary<UiScreens, GameObject> screensPrefabs = new();
        private List<BaseUiScreenController> openedScreens = new();
        private Queue<BaseUiScreenController> queueToBeOpened = new();
        
        public void Initialize()
        {
            foreach (UiScreens uiScreen in Enum.GetValues(typeof(UiScreens)))
            {
                addressableController.Load<GameObject>(uiScreen.ToString(), loadedScreen =>
                {
                    screensPrefabs.Add(uiScreen, loadedScreen);

                    //todo: kinda a crutch, should be normal pipeline of initialization with callback, or prewarm system or smth like that
                    if (screensPrefabs.Count == Enum.GetValues(typeof(UiScreens)).Length)
                    {
                        Open(UiScreens.Main, new BaseUiModel
                        {
                            IsPopUp = false
                        });
                    }
                });
            }
        }
        
        public void CloseAllPopUps()
        {
            var popUpsThatShouldBeClosed = openedScreens.Where(screen => screen.IsPopUp).ToList();

            foreach (var openedPopUp in popUpsThatShouldBeClosed)
            {
                openedPopUp.Close();
            }
        }

        public void Open(UiScreens screen, BaseUiModel model)
        {
            var popUp = CreatePopUp(screen, model);
            OpenPopUp(popUp);
        }

        public void OpenInQueue(UiScreens screen, BaseUiModel model)
        {
            var popUp = CreatePopUp(screen, model);
            queueToBeOpened.Enqueue(popUp);
            
            CheckIfPopUpFromQueueCanBeOpened();
        }

        private void OpenPopUp(BaseUiScreenController popUp)
        {
            popUp.Open();
            openedScreens.Add(popUp);
            popUp.Closed += OnScreenClosed;
        }

        private void CheckIfPopUpFromQueueCanBeOpened()
        {
            if (IsPopUpFromQueueCanBeOpened)
            {
                if (queueToBeOpened.Any())
                {
                    var popUpToBeOpened = queueToBeOpened.Dequeue();
                    OpenPopUp(popUpToBeOpened);
                }
            }
        }

        private BaseUiScreenController CreatePopUp(UiScreens screen, BaseUiModel model)
        {
            var instantiatedScreenObject = Object.Instantiate(screensPrefabs[screen], uiCanvas.transform);
            var screenView = instantiatedScreenObject.GetComponent<BaseUiScreenView>();
            var popUp = CreatePopUpController(screen, screenView, model);
            popUp.Hide();

            return popUp;
        }
        
        private BaseUiScreenController CreatePopUpController(UiScreens screen, BaseUiScreenView screenView, BaseUiModel model)
        {
            BaseUiScreenController uiScreenController = screen switch
            {
                UiScreens.Main => new MainUiScreenController(screenView, model),
                UiScreens.Info => new InfoUiScreenController(screenView, model),
                _ => throw new ArgumentOutOfRangeException(nameof(screen), screen, null)
            };

            diContainer.Inject(uiScreenController);
            
            return uiScreenController;
        }

        private void OnScreenClosed(BaseUiScreenController controller)
        {
            openedScreens.Remove(controller);
            CheckIfPopUpFromQueueCanBeOpened();
        }
    }
}
