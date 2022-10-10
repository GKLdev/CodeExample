using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public static class CompCollision
    {

        // *****************************
        // CheckCollision
        // *****************************
        public static bool CheckCollision(StatePlayerController _state, Vector3 _pos, float _radius)
        {
            return ResolveCdtContacts(_pos, _radius, _state.dynamicData.collidersCashe, 1 << _state.dynamicData.config.p_levelCdtLayer, ref _state.dynamicData.cdtContactsCount);
        }

        // *****************************
        // CheckTrigger
        // *****************************
        public static bool CheckTriggers(StatePlayerController _state, Vector3 _pos, float _radius)
        {
            return ResolveCdtContacts(_pos, _radius, _state.dynamicData.triggersCashe, 1 << _state.dynamicData.config.p_levelTriggerCdtLayer, ref _state.dynamicData.trgContactsCount);
        }

        // *****************************
        // ResolveCdtContacts
        // *****************************
        static bool ResolveCdtContacts(Vector3 _pos, float _radius, Collider[] _cashe, int _layerMask, ref int _contacts)
        {
            int contacts = Physics.OverlapSphereNonAlloc(_pos, _radius, _cashe, _layerMask);
            _contacts = contacts;

            bool result = contacts > 0;
            return result;
        }
    }
}