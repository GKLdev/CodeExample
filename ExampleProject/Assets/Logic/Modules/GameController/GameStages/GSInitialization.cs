using Factories.PlayerFactory_Public;
using Modules.ArrowPointer_Public;
using Modules.GameController_Public;
using Modules.Input_Public;
using Modules.LevelController_Public;
using Modules.UIController_Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.GameController
{
    public class GSInitialization : GameStageBase
    {
        public GSInitialization(StateGameController _stage) : base(_stage)
        {
        }


        // *****************************
        // OnStageStarted
        // *****************************
        protected override void OnStageStarted()
        {
            base.OnStageStarted();

            SetupUI();
            SpawnOrResetPlayer();
            SetInputcontext();
            ResetLevel();

            CompStagesManager.SetStageTo(state, GameStage.Gameplay);
        }

        // *****************************
        // SetupUI
        // *****************************
        void SetupUI()
        {
            state.dependencies.Get<IUIController>().TogglePanel(UiPanel.Undef, true);
            state.dependencies.Get<IArrowPointer>().ToggleArrow(false);
        }

        // *****************************
        // SpawnOrResetPlayer
        // *****************************
        void SpawnOrResetPlayer()
        {
            Vector3 spawnPos = state.dependencies.Get<ILevelController>().GetPlayerSpawnPos();

            var factory = state.dependencies.Get<IPlayerFactory>();
            var player  = factory.GetLastCreatedPlayer();

            bool playerAlreadySpawned = player != null;
            if (playerAlreadySpawned)
            {
                player.TeleportToPosition(spawnPos);
                player.ResetPlayer();
            }
            else
            {
                player = factory.CreateAtPosition(spawnPos);
            }
        }

        // *****************************
        // SetInputcontext
        // *****************************
        void SetInputcontext()
        {
            var inputCtrl = state.dependencies.Get<IInputController>();
            inputCtrl.SetContext(InputContext.Undef);
        }

        // *****************************
        // ResetLevel
        // *****************************
        void ResetLevel()
        {
            state.dependencies.Get<ILevelController>().ResetLevel();
        }
    }
}