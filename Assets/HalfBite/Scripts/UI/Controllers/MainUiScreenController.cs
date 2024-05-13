using HalfBite.Scripts.UI.Models;
using HalfBite.Scripts.UI.Views;
using Zenject;

namespace HalfBite.Scripts.UI.Controllers
{
    public class MainUiScreenController : BaseUiScreenController
    {
        [Inject] private UiController uiController;
        
        private MainUiScreenView mainUiScreenView;

        public MainUiScreenController(BaseUiScreenView uiScreenView, BaseUiModel uiScreenModel) : base(uiScreenView, uiScreenModel)
        {
            mainUiScreenView = (MainUiScreenView) uiScreenView;
        }

        protected override void OnOpen()
        {
            mainUiScreenView.PopUpButtonPressed += OnOpenPopUpButtonPressed;
            mainUiScreenView.QueueButtonPressed += OnOpenQueueButtonPressed;
        }

        protected override void OnClose()
        {
            mainUiScreenView.PopUpButtonPressed -= OnOpenPopUpButtonPressed;
            mainUiScreenView.QueueButtonPressed -= OnOpenQueueButtonPressed;
        }

        private void OnOpenPopUpButtonPressed()
        {
            uiController.Open(UiScreens.Info, new InfoUiModel
            {
                Title = "PopUp#" + uiController.PopUpsOpenedCount,
                Body = "In title you can see how many popups are opened"
            });
        }
        
        private void OnOpenQueueButtonPressed()
        {
            uiController.OpenInQueue(UiScreens.Info, new InfoUiModel
            {
                Title = "First PopUp from Queue",
                Body = "I'm first!",
                IsCloseAllButtonActive = false,
                IsOpenNextButtonActive = false
            });   
            
            uiController.OpenInQueue(UiScreens.Info, new InfoUiModel
            {
                Title = "Second PopUp from Queue",
                Body = "I'm second!",
                IsCloseAllButtonActive = false,
                IsOpenNextButtonActive = true
            });      
            
            uiController.OpenInQueue(UiScreens.Info, new InfoUiModel
            {
                Title = "Third PopUp from Queue",
                Body = "I'm third!",
                IsCloseAllButtonActive = false,
                IsOpenNextButtonActive = false
            });
        }
    }
}