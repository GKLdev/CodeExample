using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Input_Public
{
    public interface IControllable
    {
        void SendCommand(int _commandId, CommandParams _params);
        void SendCommand(int _commandId);
        void Init();
    }

    public abstract class CommandParams
    {

    }
}