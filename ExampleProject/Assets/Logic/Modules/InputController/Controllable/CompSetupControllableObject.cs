using Modules.Input_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompSetupControllableObject
    {

        // *****************************
        // AssignControllableObj
        // *****************************
        public static void AssignControllableObj(StateInputController _state, IControllable _obj)
        {
            CompCheckModuleStatus.CheckInitialized(_state, true);

            bool isNull = _obj == null;
            if (isNull)
            {
                throw new System.Exception($" Trying to assign contollable object which is NULL");
            }

            _state.dynamicData.controlledObj = _obj;
        }
    }
}