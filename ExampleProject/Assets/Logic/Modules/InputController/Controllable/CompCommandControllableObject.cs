using Factories.PlayerFactory_Public;
using Modules.Input_Public;
using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace Modules.InputCtrl
{
    public static class CompCommandControllableObject
    {
        // *****************************
        // TrySendCommandToControllable
        // *****************************
        public static void TrySendCommandToControllable(StateInputController _state, int _commandId, CommandParams _params)
        {
            bool isControllableObjPresent = _state.dynamicData.controlledObj != null;
            if (!isControllableObjPresent)
            {
                Debug.LogWarning("Controllable obj not specified!");
                return;
            }

            _state.dynamicData.controlledObj.SendCommand(_commandId, _params);
        }

        // *****************************
        // TrySendCommandToControllable
        // *****************************
        public static void TrySendCommandToControllable(StateInputController _state, int _commandId)
        {
            bool isControllableObjPresent = _state.dynamicData.controlledObj != null;
            if (!isControllableObjPresent)
            {
                Debug.LogWarning("Controllable obj not specified!");
                return;
            }

            _state.dynamicData.controlledObj.SendCommand(_commandId);
        }

        // *****************************
        // SentMoveCommandToPlayer
        // *****************************
        public static bool SentMoveCommandToPlayer(StateInputController _state)
        {
            FormParams(_state);

            if (_state.dynamicData.debugMode)
            {
                Debug.DrawLine(_state.dynamicData.arrowTargetingStartPoint, _state.dynamicData.arrowTargetingEndPoint, Color.green, Time.deltaTime);
            }

            bool blindZone = _state.dynamicData.arrowTargetingAtBlindZone;
            if (blindZone)
            {
                return false;
            }

            int commandId = _state.dynamicData.config.p_plrMoveCommand;
            TrySendCommandToControllable(_state, commandId, _state.dynamicData.playerMoveCommandParams);
            return true;
        }

        // *****************************
        // FormParams
        // *****************************
        static void FormParams(StateInputController _state)
        {
            CommandParamsPlrMove commandParams = _state.dynamicData.playerMoveCommandParams;
            commandParams.startingPos = _state.dynamicData.arrowTargetingStartPoint;

            IPlayerController   player  = _state.dependencies.Get<IPlayerFactory>().GetLastCreatedPlayer();
            bool                error   = player == null;
            if (error)
            {
                throw new System.Exception($"SentMoveCommandToPlayer(): Player Is NULL!");
            }

            var playerPos = player.GetCurrentPosition();
            commandParams.destinationPos = playerPos + (_state.dynamicData.arrowTargetingEndPoint - _state.dynamicData.arrowTargetingStartPoint);
        }
    }
}