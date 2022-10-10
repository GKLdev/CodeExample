using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public static class CompDebugArrow
    {


        // *****************************
        // OnDebugUpdate
        // *****************************
        public static void OnDebugUpdate(StateArrowPointer _state)
        {
            if (_state.debugMode)
            {
                CompSetupArrow.SetStartPoint(_state, _state.debugStart.position);
                CompSetupArrow.SetEndPoint(_state, _state.debugEnd.position);
            }
        }
    }
}