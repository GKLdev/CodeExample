using Modules.GameController_Public;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.LevelController
{
    public static class CompCollidersReportHandler
    {

        // *****************************
        // OnCollisionReport
        // *****************************
        public static void OnCollisionReport(StateLevelController _state, Collider _col)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialied);

            PaintAllWallsReedAndSetDefeat(_state);
        }

        // *****************************
        // OnCollisionReport
        // *****************************
        public static void OnTriggerReport(StateLevelController _state, Collider _trg)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(_state.dynamicData.initialied);
            FinishgameAndSetVictory(_state);
        }

        // *****************************
        // PaintAllWallsReedAndSetDefeat
        // *****************************
        static void PaintAllWallsReedAndSetDefeat(StateLevelController _state)
        {
            for (int i = 0; i < _state.dynamicData.cashedMeshRenderers.Length; i++)
            {
                _state.dynamicData.cashedMeshRenderers[i].material = _state.obstaclesHighlightMaterial;
            }

            _state.dependencies.Get<IGameController>().FinishGame(GameResult.Defeat);
        }

        // *****************************
        // FinishgameAndSetVictory
        // *****************************
        static void FinishgameAndSetVictory(StateLevelController _state)
        {
            _state.dependencies.Get<IGameController>().FinishGame(GameResult.Victory);
        }
    }
}