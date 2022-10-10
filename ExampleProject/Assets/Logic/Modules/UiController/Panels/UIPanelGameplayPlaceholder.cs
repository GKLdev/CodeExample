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
    public class UIPanelGameplayPlaceholder : UIPanelControllerBase
    {

        // *****************************
        // OnRestartButtonClick
        // *****************************
        public void OnRestartButtonClick()
        {
            dependencies.Get<IGameController>().ForceStage(GameStage.GameInitiazation);
        }
    }
}