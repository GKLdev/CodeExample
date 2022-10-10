using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public static class CompToggleArrow
    {
        // *****************************
        // Toggle
        // *****************************
        public static void Toggle(StateArrowPointer _state, bool _val)
        {
            bool ignore = _val == _state.dynamicData.isVisible;
            if (ignore)
            {
                return;
            }

            _state.root.gameObject.SetActive(_val);
            _state.dynamicData.isVisible = _val;

            if (_state.dynamicData.isVisible)
            {
                CompSetupArrow.SetupArrow(_state);
            }
        }
    }
}