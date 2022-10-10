using Modules.Input_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.InputCtrl
{
    public class CtrlInputController : LogicBase, IModuleInit, IModuleUpdate, IInputController
    {
        [SerializeField]
        StateInputController state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.Init(state, _dep);
        }

        // *****************************
        // SetContext
        // *****************************
        public void SetContext(InputContext _context)
        {
            CompSetContext.SetInputContext(state, _context);
        }

        // *****************************
        // AssignControllableObject
        // *****************************
        public void AssignControllableObject(IControllable _obj)
        {
            CompSetupControllableObject.AssignControllableObj(state, _obj);
        }

        // *****************************
        // OnUpdate
        // *****************************
        public void OnUpdate()
        {
            CompProcessInput.OnInputUpdate(state);
        }

        // *****************************
        // GetArrowPointingValues
        // *****************************
        public void GetArrowTargetingValues(out bool atBlindZone, out bool targetingInProgress, out Vector3 startPos, out Vector3 endPos)
        {
            CompArrowTargeting.ReturnArrowTargetingValues(state, out atBlindZone, out targetingInProgress, out startPos, out endPos);
        }
    }
}