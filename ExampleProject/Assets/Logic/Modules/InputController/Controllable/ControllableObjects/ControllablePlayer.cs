using Modules.Input_Public;
using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public class ControllablePlayer : LogicBase, IControllable
    {
        public LogicBase player;

        IPlayerController   plrIface;
        bool                initialized = false;

        // *****************************
        // Init
        // *****************************
        public void Init()
        {
            plrIface = player as IPlayerController;
            bool error = plrIface == null;
            if (error)
            {
                throw new System.Exception($"Failed to cast 'player' field to IPlayerController!");
            }

            initialized = true;
        }

        // *****************************
        // SendCommand
        // *****************************
        public void SendCommand(int _commandId, CommandParams _params)
        {
            switch (_commandId)
            {
                case 0:
                    MovePlayer(_params);
                    break;
                default:
                    break;
            }
        }

        // *****************************
        // SendCommand
        // *****************************
        public void SendCommand(int _commandId)
        {
            throw new System.NotImplementedException();
        }

        // *****************************
        // MovePlayer
        // *****************************
        void MovePlayer(CommandParams _params)
        {
            CommandParamsPlrMove plrCommand = (CommandParamsPlrMove)_params;

            bool error = plrCommand == null;
            if (error)
            {
                throw new System.Exception($"Wrong CommandParams: CommandParamsPlrMove container expected!");
            }


            bool notinitialized = !initialized;
            if (notinitialized)
            {
                throw new System.Exception($"Controllable obj MUST be initialized before usage!");
            }

            plrIface.OrderMoveToPosition(plrCommand.destinationPos);
        }
    }
}