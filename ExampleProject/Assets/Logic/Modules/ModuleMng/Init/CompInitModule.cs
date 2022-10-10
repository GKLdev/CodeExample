using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng
{
    public static class CompInitModule
    {

        // *****************************
        // Init
        // *****************************
        public static void Init(StateModuleMng _state)
        {
            bool alreadyInitialized = CompCheckModuleStatus.CheckIfInitialized(_state);
            if (alreadyInitialized)
            {
                return;
            }

            _state.dependencies.Init();
            _state.dynamicData.isInitialised = true;

            InitModulesSequence(_state);
            InitRuntimeUpdateSequence(_state);
        }

        // *****************************
        // InitModulesSequence
        // *****************************
        static void InitModulesSequence(StateModuleMng _state)
        {
            for (int i = 0; i < _state.initializationSequence.Count; i++)
            {
                (_state.initializationSequence[i] as IModuleInit)?.InitModule(_state.dependencies);
            }
        }


        // *****************************
        // InitRuntimeUpdateSequence
        // *****************************
        static void InitRuntimeUpdateSequence(StateModuleMng _state)
        {
            for (int i = 0; i < _state.updateSequence.Count; i++)
            {
                IModuleUpdate module = _state.updateSequence[i] as IModuleUpdate;

                bool castFailed = module == null;
                if (castFailed)
                {
                    Debug.LogWarning($"Module cannot be added since it does not implement IModuleUpdate or its NULL!");
                    continue;
                }

                CompAddOrRemoveToUpdateSequence.AddToUpdateInternal(_state, module);
            }
        }
    }
}