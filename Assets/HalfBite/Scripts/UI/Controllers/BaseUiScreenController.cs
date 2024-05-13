using System;
using HalfBite.Scripts.UI.Models;
using HalfBite.Scripts.UI.Views;
using Zenject;

namespace HalfBite.Scripts.UI.Controllers
{
    public abstract class BaseUiScreenController
    {
        [Inject] protected UiController uiController;

        public bool IsPopUp => uiScreenModel.IsPopUp;

        public event Action<BaseUiScreenController> Closed; 
        public event Action Opened; 
        
        protected BaseUiScreenView uiScreenView;
        protected BaseUiModel uiScreenModel;
        
        protected BaseUiScreenController(BaseUiScreenView uiScreenView, BaseUiModel uiScreenModel)
        {
            this.uiScreenView = uiScreenView;
            this.uiScreenModel = uiScreenModel;
        }

        protected abstract void OnOpen();

        public void Open()
        {
            uiScreenView.Open(uiScreenModel);
            Opened?.Invoke();
            Show();
            OnOpen();
        }
        
        public void Close()
        {
            Closed?.Invoke(this);
            OnClose();
            Hide();
            uiScreenView.Close();
        }

        public void Show()
        {
            uiScreenView.gameObject.SetActive(true);
        }

        public void Hide()
        {
            uiScreenView.gameObject.SetActive(false);
        }
        
        protected abstract void OnClose();
    }
}