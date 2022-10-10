using Modules.LevelController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompWorldInteraction
    {

        // *****************************
        // TryReportCollision
        // *****************************
        public static void TryReportCollision(StatePlayerController _state)
        {
            for (int i = 0; i < _state.dynamicData.cdtContactsCount; i++)
            {
                _state.dependencies.Get<ILevelController>().ReportCollision(_state.dynamicData.collidersCashe[i]);
            }
        }


        // *****************************
        // TryReportTrigger
        // *****************************
        public static void TryReportTrigger(StatePlayerController _state)
        {
            for (int i = 0; i < _state.dynamicData.trgContactsCount; i++)
            {
                _state.dependencies.Get<ILevelController>().ReportTrigger(_state.dynamicData.triggersCashe[i]);
            }
        }
    }
}