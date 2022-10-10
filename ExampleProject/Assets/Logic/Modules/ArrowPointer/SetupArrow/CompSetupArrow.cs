using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public static class CompSetupArrow
    {
        // *****************************
        // SetStartPoint
        // *****************************
        public static void SetStartPoint(StateArrowPointer _state, Vector3 _point)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);
            _state.dynamicData.startPoint = _point;
            SetupArrow(_state);
        }

        // *****************************
        // SetEndPoint
        // *****************************
        public static void SetEndPoint(StateArrowPointer _state, Vector3 _point)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);
            _state.dynamicData.endPoint = _point;
            SetupArrow(_state);
        }

        // *****************************
        // SetupArrow
        // *****************************
        public static void SetupArrow(StateArrowPointer _state)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.isInitialised);

            bool ignore = !_state.dynamicData.isVisible;
            if (ignore)
            {
                return;
            }

            // rotate towards dir //
            Vector3 direction       = _state.dynamicData.endPoint - _state.dynamicData.startPoint;
            bool    dirVectorIsZero = Mathf.Approximately(direction.magnitude, 0f);
            if (!dirVectorIsZero)
            {
                _state.root.transform.rotation = Quaternion.LookRotation(direction.normalized, -Vector3.forward);
            }

            // move root //
            _state.root.position = _state.dynamicData.startPoint;

            // scale meshes //
            // to scane original mesh:
            // 1) we are getting default size / world distance relatio
            // 2) scale head within min max bounds
            // 3) then calculating main mesh scale bassed on head world space length
            // 4) scale main mesh
            // 5) move head mesh to an edge of main mesh via direction

            // defaults //
            Vector3 headDefaultScale        = _state.dynamicData.headMeshDefaultScale;
            Vector3 mainDefaultScale        = _state.dynamicData.mainMeshDefaultScale;
            float   defaultSizeToDistRate   = _state.dynamicData.totalArrowHeight == 0 ? 0f : direction.magnitude / _state.dynamicData.totalArrowHeight;
            
            // config data //
            float   minHeadScaleFactor      = _state.dynamicData.config.p_minHeadScaleFactor;
            float   maxheadScaleFactor      = _state.dynamicData.config.p_maxHeadScaleFactor;
            float   minMainHorScaleFactor   = _state.dynamicData.config.p_minMainHorScaleFactor;
            float   maxMainHorScaleFactor   = _state.dynamicData.config.p_maxMainHorScaleFactor;

            // scale head //
            float   headDesiredScaleFactor         = Mathf.Clamp(defaultSizeToDistRate, minHeadScaleFactor, maxheadScaleFactor);
            float   headMeshBaseLength             = _state.arrowHead.localBounds.size.y * _state.dynamicData.headMeshHeight;
            float   headDesiredLength              = headMeshBaseLength * headDefaultScale.y * headDesiredScaleFactor;
            
            // scale main //
            float   mainMeshDesiredLenght          = direction.magnitude - headDesiredLength;
            float   mainDesiredScaleFactor         = _state.dynamicData.totalArrowHeight == 0 ? 0f : mainMeshDesiredLenght / _state.dynamicData.mainMeshHeight;
            float   mainDesiredHorScaleFactor      = Mathf.Clamp(mainDesiredScaleFactor, minMainHorScaleFactor, maxMainHorScaleFactor);

            // scale arrow //
            _state.arrowHead.transform.localScale = headDefaultScale * headDesiredScaleFactor;
            _state.arrowMain.transform.localScale = new Vector3(mainDefaultScale.x * mainDesiredHorScaleFactor, mainDefaultScale.y * mainDesiredScaleFactor, mainDefaultScale.z * mainDesiredHorScaleFactor);

            // move head //
            float mainPartLenght    = _state.arrowMain.localBounds.size.y * _state.arrowMain.transform.lossyScale.y;
            _state.arrowHead.transform.position = _state.root.position + direction.normalized * mainPartLenght;
        }
    }
}