using ReferenceDB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReferenceDB_Public
{
    public interface IReferenceDB : IDependency, IModuleInit
    {
        T GetEntry<T>(int[] _path) where T : DbEntryBase;
    }
}