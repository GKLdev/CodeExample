using ReferenceDB_Public;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceDB
{

    // *****************************
    // CompGetEntry
    // *****************************
    public static class CompGetEntry
    {
        public static T GetEntry<T>(StateReferenceDb _state, int[] _path) where T : DbEntryBase
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialised);

            bool badPath = _path == null || _path.Length == 0;
            if (badPath)
            {
                throw new Exception($"Bad entry path!");
            }

            // get entry recursively //
            DbEntryBase currEntry = _state.dbRoot;
            for (int i = 0; i < _path.Length; i++)
            {
                int currSubEntryId = _path[i];

                bool outOfRange = currEntry.subEntries == null || currSubEntryId < 0 || currEntry.subEntries.Length <= currSubEntryId;
                if (outOfRange)
                {
                    throw new Exception($"Bad path: out if range at step: {i}");
                }

                currEntry = currEntry.subEntries[currSubEntryId];
            }


            // try cast ot type //
            T result = currEntry as T;
            bool castFailed = result == null;
            if (castFailed)
            {
                throw new Exception($"Failed to cast entry to type: {typeof(T)}");
            }

            return result;
        }

    }
}