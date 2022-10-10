using Modules.Input_Public;
using Modules.ModuleMng_Public;
using Modules.PlayerController_Public;
using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    public static class CompCreatePlayer
    {

        // *****************************
        // CreatePlayer
        // *****************************
        public static IPlayerController CreatePlayer(StatePlayerFactory _state, Vector3 _pos, Transform _parent)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialised);

            IPlayerController result = Spawn(_state, _pos, _parent, out PlayerDbFacade dbfacade);         
            InitAndAddToInputCtrl(_state, dbfacade);

            _state.dynamicData.lastCreatedPlayer = result;
            return result;
        }

        // *****************************
        // Spawn
        // *****************************
        static IPlayerController Spawn(StatePlayerFactory _state, Vector3 _pos, Transform _parent, out PlayerDbFacade dbfacade)
        {
            // spawn //
            var db          = _state.dependencies.Get<IReferenceDB>();
            var plrConfig   = db.GetEntry<DbEntrySpawnablePlayer>(_state.pathToPlayer);
            
            dbfacade = GameObject.Instantiate<PlayerDbFacade>(plrConfig.playerPrototype);
            dbfacade.transform.position = _pos;

            // set parent //
            bool setParent = _parent != null;
            if (setParent)
            {
                dbfacade.transform.parent = _parent;
            }

            // cast to iface //
            IPlayerController result = dbfacade.controller as IPlayerController;

            bool failed = result == null;
            if (failed)
            {
                throw new System.Exception("Failed to cast player controller to IPlayerController!");
            }

            return result;
        }

        // *****************************
        // InitAndAddToInputCtrl
        // *****************************
        static void InitAndAddToInputCtrl(StatePlayerFactory _state, PlayerDbFacade dbfacade)
        {
            // add to update //
            var moduleMng = _state.dependencies.Get<IModuleManager>();
            moduleMng.AddToUpdateSequence(dbfacade.controller as IModuleUpdate);

            // init //
            (dbfacade.controller as IModuleInit).InitModule(_state.plrDependencies);

            var     input           = _state.dependencies.Get<IInputController>();
            var     controllable    = dbfacade.controllable as IControllable;

            bool failed = controllable == null;
            if (failed)
            {
                throw new System.Exception("Failed to cast controllable to IControllable!");
            }

            controllable.Init();
            input.AssignControllableObject(controllable);
        }
    }
}