using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ModuleMng_Public
{
    public interface IModuleManager : IModuleInit, IDependency
    {
        void AddToUpdateSequence(IModuleUpdate _module);
        void RemoveFromUpdateSequence(IModuleUpdate _module);

    }
}