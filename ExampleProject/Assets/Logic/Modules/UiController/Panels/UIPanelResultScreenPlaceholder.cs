using Modules.GameController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    /// <summary>
    /// Controller, View and Model logic here are all together only because its a placeholder
    /// Should not be like that
    /// </summary>
    public class UIPanelResultScreenPlaceholder : UIPanelControllerBase
    {
        [Header("Resources")]
        public TMPro.TextMeshProUGUI headerText;

        [Header("Settings")]
        public string victoryText;
        public string defeatText;

        // *****************************
        // OnRestartButtonClick
        // *****************************
        public void OnRestartButtonClick()
        {
            dependencies.Get<IGameController>().ForceStage(GameStage.GameInitiazation);
        }

        // *****************************
        // OnPanelOpened
        // *****************************
        protected override void OnPanelOpened()
        {
            base.OnPanelOpened();

            var     gameResult  = dependencies.Get<IGameController>().GetGameResult();
            string  text        = gameResult == GameResult.Victory ? victoryText : defeatText;
            headerText.text     = text;
        }
    }
}