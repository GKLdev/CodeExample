using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    public class StatePlayerFactory : LogicBase
    {
        [Header("Settings")]
        public int[]                pathToPlayer;
        public DependencyContainer  plrDependencies;

        public DynamicData dynamicData = new DynamicData();

        public class DynamicData
        {
            public IPlayerController lastCreatedPlayer;
            public bool initialised = false;
        }
    }
}