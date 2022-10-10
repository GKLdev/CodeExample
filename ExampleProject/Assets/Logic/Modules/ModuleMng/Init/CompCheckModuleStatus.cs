using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng
{
    public static class CompCheckModuleStatus
    {

        // *****************************
        // CheckIfInitialized
        // *****************************
        public static bool CheckIfInitialized(StateModuleMng _state)
        {
            return _state.dynamicData.isInitialised;
        }

    }
}