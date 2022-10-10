using Modules.GameController_Public;
using Modules.LevelController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public class CtrlGameController : LogicBase, IModuleInit, IModuleUpdate, IGameController
    {
        [SerializeField]
        StateGameController state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.Init(state, _dep);
        }

        // *****************************
        // ForceStage
        // *****************************
        public void ForceStage(GameStage _stage)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state.dynamicData.isInitialised);
            CompStagesManager.SetStageTo(state, _stage);
        }

        // *****************************
        // OnUpdate
        // *****************************
        public void OnUpdate()
        {
            CompStagesManager.OnUpdate(state);
        }

        // *****************************
        // SetGameResult
        // *****************************
        public void FinishGame(GameResult _result)
        {
            CompFinishGame.FinishGameWithResult(state, _result);
        }

        // *****************************
        // GetGameResult
        // *****************************
        public GameResult GetGameResult()
        {
            return CompFinishGame.GetGameResult(state);
        }
    }
}