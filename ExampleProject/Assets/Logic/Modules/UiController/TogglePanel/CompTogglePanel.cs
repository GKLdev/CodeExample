using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    public static class CompTogglePanel
    {

        // *****************************
        // TogglePanel
        // *****************************
        public static void TogglePanel(StateUIController _state, UiPanel _panelId, bool _toggle, bool _closeOthers)
        {
            int desiredId = (int)_panelId;
            for (int i = 0; i < _state.uiPanels.Length; i++)
            {
                bool panelFound = _state.uiPanels[i].GetPanelId() == desiredId;
                if (panelFound)
                {
                    _state.uiPanels[i].TogglePanel(_toggle);
                    continue;
                }

                if (_closeOthers)
                {
                    _state.uiPanels[i].TogglePanel(false);
                }
            }
        }
    }
}