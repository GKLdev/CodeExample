using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Modules.InputCtrl
{
    public static class CompArrowTargeting
    {

        // *****************************
        // SetStartingPoint
        // *****************************
        public static void SetStartingPoint(StateInputController _state)
        {
            GetScreenPointOrReset(_state, ref _state.dynamicData.arrowTargetingStartPoint);
        }

        // *****************************
        // SetEndPoint
        // *****************************
        public static void SetEndPoint(StateInputController _state)
        {
            GetScreenPointOrReset(_state, ref _state.dynamicData.arrowTargetingEndPoint);
        }

        // *****************************
        // GetScreenPointOrReset
        // *****************************
        static void GetScreenPointOrReset(StateInputController _state, ref Vector3 _targetValue)
        {
            var point = ScreenToWorldSpace(_state, Input.mousePosition, out bool error);
            if (error)
            {
                _state.dynamicData.arrowTargetingAtBlindZone    = true;
                return;
            }

            _targetValue = point;
        }

        // *****************************
        // ScreenToWorldSpace
        // *****************************
        public static Vector3 ScreenToWorldSpace(StateInputController _state, Vector3 _pos, out bool error)
        {
            // get cam ray //
            Camera  cam     = Camera.main;
            var     camPos  = cam.transform.position;
            Vector3 castDir = cam.ScreenPointToRay(_pos).direction;

            // cast to plane //
            int     contacts = Physics.RaycastNonAlloc(camPos, castDir, _state.dynamicData.camCastHits, cam.farClipPlane, 1 << _state.dynamicData.config.p_wpacePlaneCastLayer);
            bool    atleastOneContactFound = contacts > 0;

            error = !atleastOneContactFound;
            if (error)
            {
                return default;
            }

            // get pos //
            _pos = _state.dynamicData.camCastHits[0].point;

            if (_state.dynamicData.debugMode)
            {
                Debug.DrawRay(_pos, -Vector3.forward, Color.yellow, 1f);
            }
            return _pos;
        }

        // *****************************
        // ReturnArrowTargetingValues
        // *****************************
        public static void ReturnArrowTargetingValues(StateInputController _state, out bool atBlindZone, out bool targetingInProgress, out Vector3 startPos, out Vector3 endPos)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);

            targetingInProgress     = _state.dynamicData.inpMap.arrowTargetingMode == 0;
            atBlindZone             = _state.dynamicData.arrowTargetingAtBlindZone;
            startPos                = _state.dynamicData.arrowTargetingStartPoint;
            endPos                  = _state.dynamicData.arrowTargetingEndPoint;
        }
    }
}