using Modules.ArrowPointer_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer
{
    public class CtrlArrowPointer : LogicBase, IModuleInit, IArrowPointer
    {
        [SerializeField]
        StateArrowPointer state;

        // *****************************
        // InitModule
        // *****************************
        public void InitModule(DependencyContainer _dep)
        {
            CompInitModule.Init(state, _dep);
        }

        // *****************************
        // SetEndPoint
        // *****************************
        public void SetEndPoint(Vector3 _pos)
        {
            CompSetupArrow.SetEndPoint(state, _pos);
        }


        // *****************************
        // SetStartPoint
        // *****************************
        public void SetStartPoint(Vector3 _pos)
        {
            CompSetupArrow.SetStartPoint(state, _pos);
        }

        // *****************************
        // ToggleArrow
        // *****************************
        public void ToggleArrow(bool _val)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(state.dynamicData.isInitialised);
            CompToggleArrow.Toggle(state, _val);
        }

        // *****************************
        // Update
        // *****************************
        private void Update()
        {
            CompDebugArrow.OnDebugUpdate(state);
        }
    }
}