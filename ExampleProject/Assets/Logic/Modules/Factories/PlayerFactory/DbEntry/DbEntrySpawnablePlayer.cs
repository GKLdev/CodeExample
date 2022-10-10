using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Factories.PlayerFactory
{
    [CreateAssetMenu(fileName = "SpawnablePlayer", menuName = "ReferenceDb/Spawnable/PlayerCtrl")]
    public class DbEntrySpawnablePlayer : DbEntryBase
    {
        public PlayerDbFacade playerPrototype;
    }
}