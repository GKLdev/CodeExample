using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompInitPlayer
    {

        // *****************************
        // Init
        // *****************************
        public static void Init(StatePlayerController _state, DependencyContainer _dep)
        {
            _state.dependencies = _dep;

            var cfg = _dep.Get<IReferenceDB>().GetEntry<PlayerConfig>(_state.pathToConfig);
            _state.dynamicData.config = ScriptableObject.Instantiate(cfg);

            _state.dynamicData.collidersCashe = new Collider[_state.dynamicData.config.p_maxCdtContacts];
            _state.dynamicData.triggersCashe = new Collider[_state.dynamicData.config.p_maxCdtContacts];

            ResetPlayer(_state);
            
            CompPhysics.TogglePhysics(_state, true);
            _state.dynamicData.isInitialised = true;
        }

        // *****************************
        // Init
        // *****************************
        public static void ResetPlayer(StatePlayerController _state)
        {
            _state.dynamicData.cdtContactsCount = 0;
            _state.dynamicData.trgContactsCount = 0;
            _state.dynamicData.needMoveToDestination = false;
        }
    }
}