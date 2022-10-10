using Modules.Input_Public;
using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public class CtrlPlayerController : LogicBase, IModuleInit, IModuleUpdate, IPlayerController
    {
        [SerializeField]
        StatePlayerController state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitPlayer.Init(state, _dep);
        }

        // *****************************
        // OnUpdate
        // *****************************
        public void OnUpdate()
        {
            CompPhysics.UpdatePhysics(state);
        }

        // *****************************
        // MoveToPosition
        // *****************************
        public void OrderMoveToPosition(Vector3 _pos)
        {
            CompMovement.OrderMoveToPosition(state, _pos);
        }

        // *****************************
        // TeleportToPosition
        // *****************************
        public void TeleportToPosition(Vector3 _pos)
        {
            CompMovement.TeleportToPosition(state, _pos);
        }

        // *****************************
        // GetCurrentPosition
        // *****************************
        public Vector3 GetCurrentPosition()
        {
            return CompMovement.GetCurrentPos(state);
        }

        // *****************************
        // ResetPlayer
        // *****************************
        public void ResetPlayer()
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state);
            CompInitPlayer.ResetPlayer(state);
        }
    }
}