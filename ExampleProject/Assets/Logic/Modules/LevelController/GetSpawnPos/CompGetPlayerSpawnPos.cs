using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public static class CompGetPlayerSpawnPos
    {

        // *****************************
        // GetSpawnPos
        // *****************************
        public static Vector3 GetSpawnPos(StateLevelController _state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialied);
            return _state.playerSpawnPos.position;
        }
    }
}

