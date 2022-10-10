using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController_Public
{
    public interface IUIController : IDependency
    {
        void TogglePanel(UiPanel _panelId, bool _toggle, bool _closeOthers = true);
    }

    public enum UiPanel
    {
        Undef       = -1,
        Gameplay    = 0,
        ResultScreen
    }
}