using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompInputMap
    {
        public static void ProcessInputMap(StateInputController _state)
        {
            CompClearData.ClearInputMap(_state);
            ProcessArrowModeButton(_state);
        }

        // *****************************
        // ProcessArrowModeButton
        // *****************************
        static void ProcessArrowModeButton(StateInputController _state)
        {
            string arrowModeKey = _state.dynamicData.config.p_arrowTargetingButton;
            bool arrowModeKeyDown = Input.GetButtonDown(arrowModeKey);
            if (arrowModeKeyDown)
            {
                _state.dynamicData.inpMap.arrowTargetingMode = 0;
                _state.dynamicData.inpMap.arrowTargetingJustActivated = true;
                return;
            }

            bool arrowModeKeyPressed = Input.GetButton(arrowModeKey);
            if (arrowModeKeyPressed)
            {
                _state.dynamicData.inpMap.arrowTargetingMode = 0;
                return;
            }

            bool arrowModeKeyUp = Input.GetButtonUp(arrowModeKey);
            if (arrowModeKeyUp)
            {
                _state.dynamicData.inpMap.arrowTargetingMode = 1;
            }
        }
    }

    [System.Serializable]
    public class InputMap
    {
        // -1: idle
        //  0: targeting
        //  1: button is just up
        public int  arrowTargetingMode          = -1;
        public bool arrowTargetingJustActivated = false;
    }

}