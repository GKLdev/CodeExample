using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    public static class CompGetCreated
    {

        // *****************************
        // GetLastCreated
        // *****************************
        public static IPlayerController GetLastCreated(StatePlayerFactory _state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialised);
            return _state.dynamicData.lastCreatedPlayer;
        }
    }
}