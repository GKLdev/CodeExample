using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.UIController
{
    /// <summary>
    /// this shoud be used as a controller only
    /// all panel logic should be at "Model" sub module
    /// and all visual should be at "View" sub module
    /// </summary>
    public abstract class UIPanelControllerBase : LogicBase
    {
        bool    isActive                   = false;
        bool    controllerIsInitialised    = false;
        int     panelId = -1;
        Canvas canvas;

        // *****************************
        // IsActive
        // *****************************
        public bool IsActive()
        {
            return isActive;
        }

        // *****************************
        // GetPanelId
        // *****************************
        public int GetPanelId()
        {
            return panelId;
        }

        // *****************************
        // InitPanel
        // *****************************
        public void InitPanel(DependencyContainer _dep, int _panelId)
        {
            dependencies    = _dep;
            panelId         = _panelId;

            canvas = GetComponent<Canvas>();
            bool error = canvas == null;
            if (error)
            {
                throw new System.Exception($"UI Controller {this.name} MUST have Canvas on it!");
            }

            OnInitPanel();
            controllerIsInitialised = true;
            OnFullyInitialised();
        }

        // *****************************
        // OnInitPanel
        // *****************************
        protected virtual void OnInitPanel()
        {

        }

        // *****************************
        // OnFullyInitialised
        // *****************************
        protected virtual void OnFullyInitialised()
        {

        }

        // *****************************
        // OpenPanel
        // *****************************
        public void TogglePanel(bool _val)
        {
            LibModuleExceptions.ExceptionIfNotInitialized(controllerIsInitialised);

            isActive        = _val;
            canvas.enabled  = isActive;

            if (isActive)
            {
                OnPanelOpened();
            } else
            {
                OnPanelClosed();
            }
        }

        // *****************************
        // OnPanelOpened
        // *****************************
        protected virtual void OnPanelOpened()
        {

        }

        // *****************************
        // OnPanelClosed
        // *****************************
        protected virtual void OnPanelClosed()
        {

        }
    }
}