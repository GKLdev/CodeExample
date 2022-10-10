using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.ArrowPointer_Public
{
    public interface IArrowPointer : IDependency
    {
        void ToggleArrow(bool _val);
        void SetStartPoint(Vector3 _pos);
        void SetEndPoint(Vector3 _pos);
    }
}