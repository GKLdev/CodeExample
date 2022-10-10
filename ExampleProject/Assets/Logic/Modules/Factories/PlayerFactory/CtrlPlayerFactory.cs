using Factories.PlayerFactory_Public;
using Modules.PlayerController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    public class CtrlPlayerFactory : LogicBase, IPlayerFactory, IModuleInit
    {
        [SerializeField]
        StatePlayerFactory state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitFactory.Init(state, _dep);
        }

        // *****************************
        // CreateAtPosition
        // *****************************
        public IPlayerController CreateAtPosition(Vector3 _pos, Transform _parent = null)
        {          
            return CompCreatePlayer.CreatePlayer(state, _pos, _parent);
        }


        // *****************************
        // GetLastCreatedPlayer
        // *****************************
        public IPlayerController GetLastCreatedPlayer()
        {
            return CompGetCreated.GetLastCreated(state);
        }
    }
}