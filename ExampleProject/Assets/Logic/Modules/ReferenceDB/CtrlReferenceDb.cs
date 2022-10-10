using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceDB
{
    public class CtrlReferenceDb : LogicBase, IReferenceDB
    {
        [SerializeField]
        StateReferenceDb state;

        // *****************************
        // GetEntry
        // *****************************
        public T GetEntry<T>(int[] _path) where T : DbEntryBase
        {
            return CompGetEntry.GetEntry<T>(state, _path);
        }


        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            state.dynamicData.initialised = true;
        }
    }
}
