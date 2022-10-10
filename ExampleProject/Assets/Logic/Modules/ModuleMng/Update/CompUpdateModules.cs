using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng
{
    public static class CompUpdateModules
    {

        // *****************************
        // InitModule
        // *****************************
        public static void UpdateModules(StateModuleMng _state)
        {
            bool allowedToUpdate = CompCheckModuleStatus.CheckIfInitialized(_state);
            if (!allowedToUpdate)
            {
                return;
            }

            for (int i = 0; i < _state.dynamicData.updateSequenceRuntime.Count; i++)
            {
                _state.dynamicData.updateSequenceRuntime[i]?.OnUpdate();
            }
        }
    }
}