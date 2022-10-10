using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public abstract class GameStageBase
    {
        protected StateGameController state;

        // *****************************
        // GameStageBase
        // *****************************
        public GameStageBase(StateGameController _state)
        {
            state = _state;
        }

        // *****************************
        // StartStage
        // *****************************
        public void StartStage()
        {
            OnStageStarted();
        }

        // *****************************
        // Finishstage
        // *****************************
        public void Finishstage()
        {
            OnStageFinished();
        }

        // *****************************
        // OnStageStarted
        // *****************************
        protected virtual void OnStageStarted()
        {

        }

        // *****************************
        // OnStageFinished
        // *****************************
        public virtual void OnStageUpdate()
        {

        }

        // *****************************
        // OnStageFinished
        // *****************************
        protected virtual void OnStageFinished()
        {

        }
    }
}