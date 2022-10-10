using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    public class StatePlayerController : LogicBase
    {
        [Header("Reources")]
        public Transform        root;
        public int[]            pathToConfig;
        public SphereCollider   plrCollider;

        public DynamicData  dynamicData = new DynamicData();

        [System.Serializable]
        public class DynamicData
        {
            public bool         physicsEnabled              = false;
            public bool         needMoveToDestination       = false;
            public Vector3      startPoint                  = Vector3.zero;
            public Vector3      destinationPoint            = Vector3.zero;
            public Vector3      currentDirection            = Vector3.zero;

            public Collider[] collidersCashe;
            public Collider[] triggersCashe;

            public int cdtContactsCount = 0;
            public int trgContactsCount = 0;

            public bool collisionHappened   = false;
            public bool triggerHappened     = false;

            public PlayerConfig config;

            public bool isInitialised = false;
        }
    }
}