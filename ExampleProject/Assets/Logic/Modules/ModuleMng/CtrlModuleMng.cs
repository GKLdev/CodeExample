using Modules.ModuleMng_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng
{
    public class CtrlModuleMng : LogicBase, IModuleManager
    {
        [SerializeField]
        StateModuleMng state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.Init(state);
        }

        // *****************************
        // AddToUpdateSequence
        // *****************************
        public void AddToUpdateSequence(IModuleUpdate _module)
        {
            CompAddOrRemoveToUpdateSequence.AddToUpdate(state, _module);
        }

        // *****************************
        // RemoveFromUpdateSequence
        // *****************************
        public void RemoveFromUpdateSequence(IModuleUpdate _module)
        {
            CompAddOrRemoveToUpdateSequence.RemoveFromUpdate(state, _module);
        }

        // *****************************
        // Update
        // *****************************
        void Update()
        {
            CompUpdateModules.UpdateModules(state);
        }
    }
}