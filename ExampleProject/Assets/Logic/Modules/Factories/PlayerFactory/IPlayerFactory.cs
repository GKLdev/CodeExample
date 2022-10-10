using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory_Public
{
    public interface IPlayerFactory : IDependency
    {
        public IPlayerController CreateAtPosition(Vector3 _pos, Transform _parent = null);
        public IPlayerController GetLastCreatedPlayer();
    }
}