using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompMovement
    {
        // *****************************
        // OrderMoveToPosition
        // *****************************
        public static void OrderMoveToPosition(StatePlayerController _state, Vector3 _pos)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);

            _state.dynamicData.startPoint               = _state.root.position;
            _state.dynamicData.destinationPoint         = _pos;
            _state.dynamicData.currentDirection         = _pos - _state.dynamicData.startPoint;
            _state.dynamicData.needMoveToDestination    = true;
        }

        // *****************************
        // TeleportToPosition
        // *****************************
        public static void TeleportToPosition(StatePlayerController _state, Vector3 _pos)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);

            _state.transform.position = _pos;
        }

        // *****************************
        // GetCurrentPos
        // *****************************
        public static Vector3 GetCurrentPos(StatePlayerController _state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);
            return _state.root.position;
        }
    }
}