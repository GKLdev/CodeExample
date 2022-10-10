using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public class StateArrowPointer : LogicBase
    {
        [Header("Resources")]
        public Transform root;
        public MeshRenderer arrowMain;
        public MeshRenderer arrowHead;

        public bool         visibleByDefault = false;

        [Header("Debug")]
        public bool         debugMode = false;
        public Transform    debugStart;
        public Transform    debugEnd;

        [Header("Settings")]
        public int[] pathToConfig;

        public DynamicData dynamicData = new DynamicData();

        [System.Serializable]
        public class DynamicData
        {
            public ArrowConfig config;

            public Vector3  startPoint;
            public Vector3  endPoint;

            public float headMeshHeight;
            public float mainMeshHeight;
            public float totalArrowHeight;
            public Vector3  headMeshDefaultScale;
            public Vector3  mainMeshDefaultScale;

            public bool     isInitialised   = false;
            public bool     isVisible       = false;
        }
    }
}