using System;
using Source.Modules.UI.Window;
using UnityEngine;
using Window.Source.Modules.UI.Window;

namespace Game.Source.Modules.Game.Scripts
{
    internal class UIRoot: MonoBehaviour
    {
        private WindowService _windowService;
        private UIFactory _uiFactory;

        private WinWindow _winWindow;

        private void Awake()
        {
            _uiFactory = new UIFactory();
            _windowService = new WindowService(_uiFactory);
        }

        public void LevelFinish()
        {
            Debug.Log("Create Win window");
            _uiFactory.CreateRoot();
            _winWindow = _windowService.Create<WinWindow>();
        }
    }
}