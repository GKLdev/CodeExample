using Modules.GameController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public static class CompStagesManager
    {

        // *****************************
        // OnUpdate
        // *****************************
        public static void OnUpdate(StateGameController _state)
        {
            bool isinitialised = _state.dynamicData.isInitialised;
            if (!isinitialised)
            {
                return;
            }

            _state.dynamicData.gameStages[_state.dynamicData.currentStage]?.OnStageUpdate();
        }

        // *****************************
        // SetStage
        // *****************************
        public static void SetStageTo(StateGameController _state, GameStage _stage)
        {
            GetCurrentStage(_state)?.Finishstage();
            _state.dynamicData.currentStage = _stage;
            GetCurrentStage(_state)?.StartStage();
        }

        // *****************************
        // GetCurrentStage
        // *****************************
        public static GameStageBase GetCurrentStage(StateGameController _state)
        {
            return _state.dynamicData.gameStages[_state.dynamicData.currentStage];
        }
    }
}