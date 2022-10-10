using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompCheckModuleStatus
    {
        // *****************************
        // CheckInitialized
        // *****************************
        public static bool CheckInitialized(StateInputController _state, bool _exceptionOnFailure = false)
        {
            bool result = _state.dynamicData.isInitialised;

            bool exception = !result && _exceptionOnFailure;
            if (exception)
            {
                throw new System.Exception($"Inut controller MUST be initialised nefore usage!");
            }

            return result;
        }

    }
}