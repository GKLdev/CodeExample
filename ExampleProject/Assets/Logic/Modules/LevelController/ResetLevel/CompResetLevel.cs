using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public static class CompResetLevel
    {

        // *****************************
        // InitModule
        // *****************************
        public static void Reset(StateLevelController _state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialied);
            ResetObstaclesMaterials(_state);
        }

        // *****************************
        // ResetObstaclesMaterials
        // *****************************
        static void ResetObstaclesMaterials(StateLevelController _state)
        {
            for (int i = 0; i < _state.dynamicData.cashedMeshRenderers.Length; i++)
            {
                _state.dynamicData.cashedMeshRenderers[i].material = _state.defaultobstacleMaterial;
            }
        }
    }
}