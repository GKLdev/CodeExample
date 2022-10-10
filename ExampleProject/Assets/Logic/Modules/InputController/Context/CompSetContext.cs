using Modules.Input_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompSetContext
    {

        // *****************************
        // SetContext
        // *****************************
        public static void SetInputContext(StateInputController _state, InputContext _context)
        {
            CompCheckModuleStatus.CheckInitialized(_state, true);

            CompClearData.ClearAllInputData(_state);
            _state.dynamicData.currentContext = _context;
        }
    }
}