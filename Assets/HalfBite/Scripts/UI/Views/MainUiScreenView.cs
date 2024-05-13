using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HalfBite.Scripts.UI.Views
{
    public class MainUiScreenView : BaseUiScreenView
    {
        [SerializeField] private Button queueButton;
        [SerializeField] private Button popUpButton;

        public event Action QueueButtonPressed;
        public event Action PopUpButtonPressed;

        protected override void SubscribeAll()
        {
            queueButton.onClick.AddListener(OnSettingsButtonPressed);
            popUpButton.onClick.AddListener(OnInfoButtonPressed);
        }

        protected override void UnsubscribeAll()
        {
            queueButton.onClick.RemoveAllListeners();
            popUpButton.onClick.RemoveAllListeners();
        }

        private void OnSettingsButtonPressed()
        {
            QueueButtonPressed?.Invoke();
        }
        
        private void OnInfoButtonPressed()
        {
            PopUpButtonPressed?.Invoke();
        }
    }
}