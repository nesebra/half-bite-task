using HalfBite.Scripts.UI.Models;
using HalfBite.Scripts.UI.Views;

namespace HalfBite.Scripts.UI.Controllers
{
    public class InfoUiScreenController : BaseUiScreenController
    {
        private readonly InfoUiScreenView infoUiScreenView;

        public InfoUiScreenController(BaseUiScreenView uiScreenView, BaseUiModel uiScreenModel) : base(uiScreenView, uiScreenModel)
        {
            infoUiScreenView = (InfoUiScreenView) uiScreenView;
        }

        protected override void OnOpen()
        {
            infoUiScreenView.CloseButtonPressed += OnCloseButtonPressed;
            infoUiScreenView.CloseAllButtonPressed += OnCloseAllButtonPressed;
            infoUiScreenView.OpenNextButtonPressed += OnOpenNextButtonPressed;
        }

        protected override void OnClose()
        {
            infoUiScreenView.CloseButtonPressed -= OnCloseButtonPressed;
            infoUiScreenView.CloseAllButtonPressed -= OnCloseAllButtonPressed;
            infoUiScreenView.OpenNextButtonPressed -= OnOpenNextButtonPressed;
        }

        private void OnCloseButtonPressed()
        {
            Close();
        }
        
        private void OnCloseAllButtonPressed()
        {
            uiController.CloseAllPopUps();
        }
        
        private void OnOpenNextButtonPressed()
        {
            uiController.Open(UiScreens.Info, new InfoUiModel
            {
                Title = "PopUp#" + uiController.PopUpsOpenedCount,
                Body = "This is a popup which was created from the same type of popup!"
            });
        }
    }
}