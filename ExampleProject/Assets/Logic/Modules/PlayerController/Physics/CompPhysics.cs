using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompPhysics
    {
        // *****************************
        // UpdatePhysics
        // *****************************
        public static void UpdatePhysics(StatePlayerController _state)
        {
            bool needUpdate = _state.dynamicData.physicsEnabled;
            if (!needUpdate)
            {
                return;
            }

            CompPhysicsMoveToTarget.ProcessMoveToTarget(_state);
            CompWorldInteraction.TryReportCollision(_state);
            CompWorldInteraction.TryReportTrigger(_state);
        }

        // *****************************
        // TogglePhysics
        // *****************************
        public static void TogglePhysics(StatePlayerController _state, bool _val)
        {
            _state.dynamicData.physicsEnabled = _val;
        }    

    }
}