using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public class StateLevelController : LogicBase
    {
        [Header("Resources")]
        public Transform    obstaclesRoot;
        public Collider     endGameTrigger;
        public Material     obstaclesHighlightMaterial;
        public Material     defaultobstacleMaterial;
        public Transform    playerSpawnPos;

        public DynamicData dynamicData = new DynamicData();

        [System.Serializable]
        public class DynamicData
        {
            public Collider[]       obstacles;
            public Collider[]       triggers;
            public MeshRenderer[]   cashedMeshRenderers;

            public bool initialied = false;
        }
    }
}