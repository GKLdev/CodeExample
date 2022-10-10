using Modules.GameController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public static class CompInitModule
    {

        // *****************************
        // Init
        // *****************************
        public static void Init(StateGameController _state, DependencyContainer _dep)
        {
            _state.dependencies                 = _dep;
            _state.dynamicData.currentStage     = GameStage.Undef;
            _state.dynamicData.gameStages       = new Dictionary<GameStage, GameStageBase>() 
            { 
                {GameStage.Undef,               null },
                {GameStage.GameInitiazation,    new GSInitialization(_state) },
                {GameStage.Gameplay,            new GSGameplay(_state) },
                {GameStage.PostGameplay,        new GSPostGame(_state) },
            };

            _state.dynamicData.isInitialised    = true;

            CompStagesManager.SetStageTo(_state, GameStage.GameInitiazation);
        }
    }
}