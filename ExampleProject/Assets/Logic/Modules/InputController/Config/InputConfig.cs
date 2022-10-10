using Modules.Input_Public;
using ReferenceDB_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    [CreateAssetMenu(fileName = "InputConfig", menuName = "ReferenceDb/Configs/InputConfig")]
    public class InputConfig : DbEntryBase
    {
        [SerializeField]
        string arrowTargetingButton;

        [SerializeField]
        InputContext defaultContext;

        [SerializeField]
        float arrowPointingBlindZone;

        [SerializeField]
        int plrMoveCommand = 0;
        [SerializeField]
        int wpacePlaneCastLayer = 0;
        [SerializeField]
        int maxCameraCastHits   = 1;

        public string       p_arrowTargetingButton  => arrowTargetingButton;
        public InputContext p_defaultContext        => defaultContext;
        public int          p_plrMoveCommand        => plrMoveCommand;
        public int          p_wpacePlaneCastLayer   => wpacePlaneCastLayer;
        public int          p_maxCameraCastHits     => maxCameraCastHits;
        public float        p_arrowPointingBlindZone => arrowPointingBlindZone;
    }
}