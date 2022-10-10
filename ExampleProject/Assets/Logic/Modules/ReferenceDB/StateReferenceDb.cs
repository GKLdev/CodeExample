using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceDB
{
    public class StateReferenceDb : LogicBase
    {
        public DbEntryBase dbRoot;
        public DynamicData dynamicData = new DynamicData();

        public class DynamicData
        {
            public bool initialised = false;
        }
    }
}