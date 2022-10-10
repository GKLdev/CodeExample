using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController_Public
{
    public interface ILevelController : IDependency
    {
        Vector3 GetPlayerSpawnPos();
        void ReportCollision(Collider _col);
        void ReportTrigger(Collider _trg);
        void ResetLevel();
    }
}