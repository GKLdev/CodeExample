using Modules.LevelController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public class CtrlLevelController : LogicBase, IModuleInit, ILevelController
    {
        [SerializeField]
        StateLevelController state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.Init(state, _dep);
        }

        // *****************************
        // GetPlayerSpawnPos
        // *****************************
        public Vector3 GetPlayerSpawnPos()
        {
            return CompGetPlayerSpawnPos.GetSpawnPos(state);
        }

        // *****************************
        // ReportCollision
        // *****************************
        public void ReportCollision(Collider _col)
        {
            CompCollidersReportHandler.OnCollisionReport(state, _col);
        }

        // *****************************
        // ReportTrigger
        // *****************************
        public void ReportTrigger(Collider _trg)
        {
            CompCollidersReportHandler.OnTriggerReport(state, _trg);
        }

        // *****************************
        // ResetLevel
        // *****************************
        public void ResetLevel()
        {
            CompResetLevel.Reset(state);
        }
    }
}