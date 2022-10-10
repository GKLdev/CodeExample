using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    public static class CompInitFactory
    {

        // *****************************
        // InitModule
        // *****************************
        public static void Init(StatePlayerFactory state, DependencyContainer _dep)
        {
            state.dependencies              = _dep;
            state.dynamicData.initialised   = true;


        }
    }
}