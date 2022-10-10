using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Input_Public
{
    public interface IInputController : IDependency
    {
        void SetContext(InputContext _context);
        void AssignControllableObject(IControllable _obj);
        void GetArrowTargetingValues(out bool atBlindZone, out bool targetingInProgress, out Vector3 startPos, out Vector3 endPos);
    }

    public enum InputContext
    {
        Undef = 0,
        Gameplay,
        ResultScreen
    }

}