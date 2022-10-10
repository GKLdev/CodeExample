using Factories.PlayerFactory_Public;
using Modules.ArrowPointer_Public;
using Modules.GameController_Public;
using Modules.Input_Public;
using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public class GSPostGame : GameStageBase
    {
        public GSPostGame(StateGameController _stage) : base(_stage)
        {
        }

        // *****************************
        // OnStageStarted
        // *****************************
        protected override void OnStageStarted()
        {
            base.OnStageStarted();

            ShowResultScreen();
        }
        // *****************************
        // ShowResultScreen
        // *****************************
        void ShowResultScreen()
        {
            var inputCtrl = state.dependencies.Get<IInputController>();
            inputCtrl.SetContext(InputContext.ResultScreen);
            
            state.dependencies.Get<IUIController>().TogglePanel(UiPanel.ResultScreen, true);
            state.dependencies.Get<IArrowPointer>().ToggleArrow(false);

            var playerCtrl = state.dependencies.Get<IPlayerFactory>().GetLastCreatedPlayer();
            playerCtrl.ResetPlayer();
        }
    }
}