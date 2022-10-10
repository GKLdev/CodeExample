using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.PlayerController
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ReferenceDb/Configs/PlayerConfig")]
    public class PlayerConfig : DbEntryBase
    {
        [SerializeField]
        [Tooltip("Time which it takes for player to reach destination")]
        float blendToDestinationTime = 1f;

        [SerializeField]
        [Tooltip("Turns on step resolve movement to avoid passing through collision on extremely high velocities.")]
        bool stepResovleMovement = true;

        [SerializeField]
        [Tooltip("Precision at which movement will be resolved. Used to avoid passing through collision on extremely high velocities")]
        float movementResolveStep = 0.1f;

        [SerializeField]
        [Tooltip("Defines maximum coliders buffer size for collision detection")]
        int maxCdtContacts = 32;

        [SerializeField]
        [Tooltip("Defines maximum coliders buffer size for trigger detection")]
        int maxTrgContacts = 32;

        [SerializeField]
        int levelCdtLayer = 0;

        [SerializeField]
        [Range(0f, 10000f)]
        float floatMaxValue = 999999f;

        [SerializeField]
        int levelTriggerCdtLayer = 0;

        public float    p_blendToDestinationTime   => blendToDestinationTime;
        public float    p_movementResolveStep      => movementResolveStep;
        public int      p_maxCdtContacts           => maxCdtContacts;
        public int      p_maxTrgContacts           => maxTrgContacts;
        public int      p_levelCdtLayer            => levelCdtLayer;
        public int      p_levelTriggerCdtLayer     => levelTriggerCdtLayer;
        public bool     p_stepResovleMovement      => stepResovleMovement;
        public float    p_floatMaxValue            => floatMaxValue;
    }
}