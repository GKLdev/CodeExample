using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompInitModule
    {

        // *****************************
        // Init
        // *****************************
        public static void Init(StateInputController _state, DependencyContainer _dep)
        {
            bool alreadyInitialized = CompCheckModuleStatus.CheckInitialized(_state);
            if (alreadyInitialized)
            {
                return;
            }

            _state.dependencies                 = _dep;

            // get config //
            var cfg = _dep.Get<IReferenceDB>().GetEntry<InputConfig>(_state.pathToConfig);
            _state.dynamicData.config = ScriptableObject.Instantiate(cfg);

            // setup defauld values //
            _state.dynamicData.currentContext   = _state.dynamicData.config.p_defaultContext;
            _state.dynamicData.camCastHits      = new RaycastHit[_state.dynamicData.config.p_maxCameraCastHits];
            CompClearData.ClearAllInputData(_state);
            _state.dynamicData.isInitialised    = true;
        }
    }
}