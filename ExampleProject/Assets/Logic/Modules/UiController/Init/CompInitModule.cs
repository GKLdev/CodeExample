using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    public static class CompInitModule
    {

        // *****************************
        // InitModule
        // *****************************
        public static void InitModule(StateUIController _state, DependencyContainer _dep)
        {
            _state.dependencies = _dep;

            for (int i = 0; i < _state.uiPanels.Length; i++)
            {
                _state.uiPanels[i].gameObject.SetActive(true);
                _state.uiPanels[i].InitPanel(_dep, i);
            }
            CompTogglePanel.TogglePanel(_state, _state.defaultOpenedPanel, true, true);

            _state.dynamicData.isInitialised = true;
        }
    }
}