using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng
{
    public class StateModuleMng : LogicBase
    {

        [Header("Modules")]
        public List<LogicBase> initializationSequence;
        public List<LogicBase> updateSequence;

        public DynamicData dynamicData = new DynamicData();

        public class DynamicData
        {
            public List<IModuleUpdate>  updateSequenceRuntime   = new List<IModuleUpdate>();
            public bool                 isInitialised           = false;
        }
    }
}