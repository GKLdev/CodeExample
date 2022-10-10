using Factories.PlayerFactory_Public;
using Modules.ArrowPointer_Public;
using Modules.Input_Public;
using Modules.PlayerController_Public;
using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public class GSGameplay : GameStageBase
    {

        public GSGameplay(StateGameController _stage) : base(_stage)
        {
        }

        IArrowPointer       arrow;
        IInputController    input;
        IPlayerController   playerCtrl;

        // *****************************
        // OnStageStarted
        // *****************************
        protected override void OnStageStarted()
        {
            base.OnStageStarted();

            arrow = state.dependencies.Get<IArrowPointer>();
            arrow.ToggleArrow(true);
            playerCtrl = state.dependencies.Get<IPlayerFactory>().GetLastCreatedPlayer();

            SetInputContext();
        }

        // *****************************
        // SetInputContext
        // *****************************
        void SetInputContext()
        {
            input = state.dependencies.Get<IInputController>();
            input.SetContext(InputContext.Gameplay);

            state.dependencies.Get<IUIController>().TogglePanel(UiPanel.Gameplay, true);
        }

        // *****************************
        // OnStageUpdate
        // *****************************
        public override void OnStageUpdate()
        {
            base.OnStageUpdate();
            UpdateArrow();
        }

        // *****************************
        // UpdateArrow
        // *****************************
        void UpdateArrow()
        {
            input.GetArrowTargetingValues(out bool atBlindZone, out bool _targetingInProgress, out Vector3 startPos, out Vector3 endPos);
            arrow.ToggleArrow(!atBlindZone);

            if (atBlindZone)
            {
                return;
            }

            var     playerPos   = playerCtrl.GetCurrentPosition();
            Vector3 arrowEndPos = _targetingInProgress ? playerPos + (endPos - startPos) : endPos;

            arrow.SetStartPoint(playerPos);
            arrow.SetEndPoint(arrowEndPos);
        }
    }
}