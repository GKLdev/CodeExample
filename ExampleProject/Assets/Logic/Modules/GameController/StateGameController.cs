using Modules.GameController_Public;
using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public class StateGameController : LogicBase
    {
        [Header("Settings")]
        public bool arrowPointingAtDestnationMode = false;

        public DynamocData dynamicData = new DynamocData();

        [System.Serializable]
        public class DynamocData
        {
            public GameStage                            currentStage;
            public Dictionary<GameStage, GameStageBase> gameStages;
            public GameResult                           gameResult = GameResult.Undef;

            public bool         isInitialised = false;
        }
    }
}