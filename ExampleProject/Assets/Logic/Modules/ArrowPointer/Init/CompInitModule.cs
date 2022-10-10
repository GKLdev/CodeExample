using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public static class CompInitModule
    {
        // *****************************
        // Init
        // *****************************
        public static void Init(StateArrowPointer _state, DependencyContainer _dep)
        {
            _state.dependencies             = _dep;

            GetConfig(_state);
            CalculateMeshValues(_state);

            _state.dynamicData.isInitialised = true;
            CompToggleArrow.Toggle(_state, _state.visibleByDefault);
        }

        // *****************************
        // GetConfig
        // *****************************
        static void GetConfig(StateArrowPointer _state)
        {
            // get config //
            var cfg = _state.dependencies.Get<IReferenceDB>().GetEntry<ArrowConfig>(_state.pathToConfig);
            _state.dynamicData.config = ScriptableObject.Instantiate(cfg);
        }

        // *****************************
        // CalculateMeshValues
        // *****************************
        static void CalculateMeshValues(StateArrowPointer _state)
        {
            _state.dynamicData.mainMeshDefaultScale = _state.arrowMain.transform.lossyScale;
            _state.dynamicData.headMeshDefaultScale = _state.arrowHead.transform.lossyScale;

            _state.dynamicData.mainMeshHeight   = _state.arrowMain.localBounds.size.y * _state.arrowMain.transform.lossyScale.y;
            _state.dynamicData.headMeshHeight   = _state.arrowHead.localBounds.size.y * _state.arrowHead.transform.lossyScale.y;
            _state.dynamicData.totalArrowHeight = _state.dynamicData.mainMeshHeight + _state.dynamicData.headMeshHeight;
        }
    }
}