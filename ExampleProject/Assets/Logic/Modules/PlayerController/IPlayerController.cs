using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController_Public
{
    public interface IPlayerController : IDependency
    {
        void OrderMoveToPosition(Vector3 _pos);
        void TeleportToPosition(Vector3 _pos);
        void ResetPlayer();
        Vector3 GetCurrentPosition();
    }
}