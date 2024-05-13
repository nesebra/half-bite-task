using System;
using HalfBite.Scripts.UI.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HalfBite.Scripts.UI.Views
{
    public class InfoUiScreenView : BaseUiScreenView
    {
        [SerializeField] private TextMeshProUGUI titleText;
        [SerializeField] private TextMeshProUGUI bodyText;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button closeAllButton;
        [SerializeField] private Button openNextButton;
        
        public event Action CloseButtonPressed;
        public event Action CloseAllButtonPressed;
        public event Action OpenNextButtonPressed;

        public override void Open(BaseUiModel uiModel)
        {
            var infoUiModel = (InfoUiModel) uiModel;
            titleText.text = infoUiModel.Title;
            bodyText.text = infoUiModel.Body;
            
            closeButton.gameObject.SetActive(infoUiModel.IsCloseButtonActive);
            closeAllButton.gameObject.SetActive(infoUiModel.IsCloseAllButtonActive);
            openNextButton.gameObject.SetActive(infoUiModel.IsOpenNextButtonActive);
            
            base.Open(uiModel);
        }

        protected override void SubscribeAll()
        {
            closeButton.onClick.AddListener(OnCloseButtonPressed);
            closeAllButton.onClick.AddListener(OnCloseAllButtonPressed);
            openNextButton.onClick.AddListener(OnOpenNextButtonPressed);
        }
        
        protected override void UnsubscribeAll()
        {
            closeButton.onClick.RemoveAllListeners();
            closeAllButton.onClick.RemoveAllListeners();
            openNextButton.onClick.RemoveAllListeners();
        }

        private void OnCloseButtonPressed()
        {
            CloseButtonPressed?.Invoke();
        }

        private void OnCloseAllButtonPressed()
        {
            CloseAllButtonPressed?.Invoke();
        }

        private void OnOpenNextButtonPressed()
        {
            OpenNextButtonPressed?.Invoke();
        }
    }
}
