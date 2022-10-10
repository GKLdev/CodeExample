using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    public class StateUIController : LogicBase
    {
        [Header("Resources")]
        public UIPanelControllerBase[]  uiPanels;
        public UiPanel                  defaultOpenedPanel = UiPanel.Undef;

        public DynamicData dynamicData = new DynamicData();

        [System.Serializable]
        public class DynamicData
        {
            public bool         isInitialised = false;
        }
    }
}