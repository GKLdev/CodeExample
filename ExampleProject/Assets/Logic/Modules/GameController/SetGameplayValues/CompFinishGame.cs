using Modules.GameController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public static class CompFinishGame
    {

        // *****************************
        // SetGameresult
        // *****************************
        public static void FinishGameWithResult(StateGameController state, GameResult _gameResult)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state.dynamicData.isInitialised);

            bool alreadyFinished = state.dynamicData.currentStage == GameStage.PostGameplay;
            if (alreadyFinished)
            {
                return;
            }

            state.dynamicData.gameResult = _gameResult;
            CompStagesManager.SetStageTo(state, GameStage.PostGameplay);
        }

        // *****************************
        // GetGameResult
        // *****************************
        public static GameResult GetGameResult(StateGameController state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state.dynamicData.isInitialised);
            return state.dynamicData.gameResult;
        }
    }
}