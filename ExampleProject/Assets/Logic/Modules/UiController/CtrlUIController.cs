using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    public class CtrlUIController : LogicBase, IModuleInit, IUIController
    {
        [SerializeField]
        StateUIController state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.InitModule(state, _dep);
        }

        // *****************************
        // TogglePanel
        // *****************************
        public void TogglePanel(UiPanel _panelId, bool _toggle,  bool _closeOthers = true)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state.dynamicData.isInitialised);
            CompTogglePanel.TogglePanel(state, _panelId, _toggle, _closeOthers);
        }
    }
}