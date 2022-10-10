using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController_Public
{
    public interface IGameController : IDependency
    {
        void ForceStage(GameStage _stage);
        void FinishGame(GameResult _result);
        GameResult GetGameResult();
    }

    public enum GameStage
    {
        Undef = -1,
        GameInitiazation,
        Gameplay,
        PostGameplay
    }

    public enum GameResult
    {
        Undef = -1,
        Victory = 0,
        Defeat
    }
}