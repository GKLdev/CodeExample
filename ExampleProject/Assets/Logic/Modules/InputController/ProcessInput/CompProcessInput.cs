using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public static class CompProcessInput
    {

        // *****************************
        // OnInputUpdate
        // *****************************
        public static void OnInputUpdate(StateInputController _state)
        {
            bool initialised = CompCheckModuleStatus.CheckInitialized(_state);
            if (!initialised)
            {
                return;
            }

            CompInputMap.ProcessInputMap(_state);
            ProcessInputContexts(_state);
        }

        // *****************************
        // ProcessInput
        // *****************************
        static void ProcessInputContexts(StateInputController _state)
        {

            switch (_state.dynamicData.currentContext)
            {
                case Input_Public.InputContext.Undef:
                    ContextUndef(_state);
                    break;
                case Input_Public.InputContext.Gameplay:
                    ContextGameplay(_state);
                    break;
                case Input_Public.InputContext.ResultScreen:
                    ContextResultScreen(_state);
                    break;
                default:
                    break;
            }
        }

        // *****************************
        // ContextUndef
        // *****************************
        static void ContextUndef(StateInputController _state)
        {
            // empty //
        }

        // *****************************
        // ContextGameplay
        // *****************************
        static void ContextGameplay(StateInputController _state)
        {
            // arrow tageting //
            bool triggerArrowTargeting = _state.dynamicData.inpMap.arrowTargetingMode == 0;
            if (triggerArrowTargeting)
            {
                bool justStarted = _state.dynamicData.inpMap.arrowTargetingJustActivated;
                if (justStarted)
                {
                    CompArrowTargeting.SetStartingPoint(_state);
                }

                CompArrowTargeting.SetEndPoint(_state);

                if (_state.dynamicData.debugMode)
                {
                    Debug.DrawLine(_state.dynamicData.arrowTargetingStartPoint, _state.dynamicData.arrowTargetingEndPoint, Color.blue, Time.deltaTime);
                }
            }

            UpdateBlindZone(_state);

            // player movement //
            bool triggerPlayerMovement = _state.dynamicData.inpMap.arrowTargetingMode == 1;
            if (triggerPlayerMovement)
            {
                bool commanWasSuccessful = CompCommandControllableObject.SentMoveCommandToPlayer(_state);
                if (commanWasSuccessful)
                {
                    // set end point to destination only when command was sent successfully
                    _state.dynamicData.arrowTargetingEndPoint = _state.dynamicData.playerMoveCommandParams.destinationPos;
                }
            }

        }

        // *****************************
        // UpdateBlindZone
        // *****************************
        public static void UpdateBlindZone(StateInputController _state)
        {
            float translationLenght = (_state.dynamicData.arrowTargetingEndPoint - _state.dynamicData.arrowTargetingStartPoint).magnitude;
            _state.dynamicData.arrowTargetingAtBlindZone = translationLenght < Mathf.Abs(_state.dynamicData.config.p_arrowPointingBlindZone) || Mathf.Approximately(translationLenght, 0f);
        }

        // *****************************
        // ContextResultScreen
        // *****************************
        static void ContextResultScreen(StateInputController _state)
        {
            // empty //
        }
    }
}