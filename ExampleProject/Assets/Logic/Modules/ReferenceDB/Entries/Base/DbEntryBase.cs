using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceDB_Public
{
    public abstract class DbEntryBase : ScriptableObject
    {
        public DbEntryBase[] subEntries;
    }
}