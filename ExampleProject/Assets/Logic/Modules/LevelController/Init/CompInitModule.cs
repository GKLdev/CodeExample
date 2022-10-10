using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public static class CompInitModule
    {

        // *****************************
        // Init
        // *****************************
        public static void Init(StateLevelController state, DependencyContainer _dep) {
            state.dependencies = _dep;

            InitColliders(state);
            InitTriggers(state);
            CasheObstaclesOriginalMaterials(state);

            state.dynamicData.initialied = true;
        }

        // *****************************
        // InitColliders
        // *****************************
        static void InitColliders(StateLevelController _state) {
            _state.dynamicData.obstacles = _state.obstaclesRoot.GetComponentsInChildren<Collider>();
        }

        // *****************************
        // InitTriggers
        // *****************************
        static void InitTriggers(StateLevelController _state)
        {
            _state.dynamicData.triggers = new Collider[1];
            _state.dynamicData.triggers[0] = _state.endGameTrigger;
        }

        // *****************************
        // CasheObstaclesOriginalMaterials
        // *****************************
        static void CasheObstaclesOriginalMaterials(StateLevelController _state)
        {
            int             obstCount       = _state.dynamicData.obstacles.Length;
            MeshRenderer[]  meshRenderers   = new MeshRenderer[obstCount];

            for (int i = 0; i < obstCount; i++)
            {
                var  meshRnd    = _state.dynamicData.obstacles[i].gameObject.GetComponent<MeshRenderer>();
                bool error      = meshRnd == null;
                if (error)
                {
                    throw new System.Exception($"Obstacle {_state.dynamicData.obstacles[i].gameObject.name} MUST have mesh renderer assigned!");
                }

                meshRnd.material = _state.defaultobstacleMaterial;
                meshRenderers[i] = meshRnd;
            }

            _state.dynamicData.cashedMeshRenderers  = meshRenderers;
        }
    }
}