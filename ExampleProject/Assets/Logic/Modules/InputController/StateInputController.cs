using Modules.Input_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public class StateInputController : LogicBase
    {

        [Header("Settings")]
        public int[]        pathToConfig;

        public DynamicData dynamicData = new DynamicData();

        [System.Serializable]
        public class DynamicData
        {
            public InputContext     currentContext = InputContext.Undef;
            public IControllable    controlledObj;
            public InputMap         inpMap = new InputMap();

            public InputConfig      config;

            public Vector3              arrowTargetingStartPoint;
            public Vector3              arrowTargetingEndPoint;

            public bool                 arrowTargetingAtBlindZone = true;
            public RaycastHit[]         camCastHits;
            public CommandParamsPlrMove playerMoveCommandParams = new CommandParamsPlrMove();

            public bool             debugMode       = false;
            public bool             isInitialised   = false;
        } 
    }
}