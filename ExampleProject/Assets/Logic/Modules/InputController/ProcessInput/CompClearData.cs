using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompClearData
    {
        // *****************************
        // ClearInputMap
        // *****************************
        public static void ClearInputMap(StateInputController _state)
        {
            _state.dynamicData.inpMap.arrowTargetingMode = -1;
            _state.dynamicData.inpMap.arrowTargetingJustActivated = false;
        }

        // *****************************
        // ClearAllInputData
        // *****************************
        public static void ClearAllInputData(StateInputController _state)
        {
            ClearInputMap(_state);
            _state.dynamicData.arrowTargetingEndPoint   = default;
            _state.dynamicData.arrowTargetingStartPoint = default;
            _state.dynamicData.arrowTargetingAtBlindZone = true;
        }
    }
}