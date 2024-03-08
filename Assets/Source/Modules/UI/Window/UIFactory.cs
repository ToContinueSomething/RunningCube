using System;
using Source.Modules.UI.Window;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Window.Source.Modules.UI.Window
{
    public class UIFactory
    {
        private const string MenuWindowPath = "UI/Windows/Menu";
        private const string RootPath = "UI/UIRoot";
        private const string WinWindowPath = "UI/Windows/WinWindow";
        private const string GameOverWindowPath = "UI/Windows/GameOver";
        private const string ShopWindowPath = "UI/Windows/Shop";
        private const string SettingsWindowPath = "UI/Windows/Settings";
        private const string LevelsWindowPath = "UI/Windows/Levels";

        private Transform _root;

        public TWindow CreateWindow<TWindow>() where TWindow : WindowBase
        {
            if (typeof(TWindow) == typeof(MenuWindow))
                return Instantiate(MenuWindowPath,_root).GetComponent<TWindow>();
            else if (typeof(TWindow) == typeof(WinWindow))
                return Instantiate(WinWindowPath,_root).GetComponent<TWindow>();
            else if (typeof(TWindow) == typeof(GameOverWindow))
                return Instantiate(GameOverWindowPath,_root).GetComponent<TWindow>();
            else if (typeof(TWindow) == typeof(ShopWindow))
                return Instantiate(ShopWindowPath,_root).GetComponent<TWindow>();
            else if (typeof(TWindow) == typeof(SettingsWindow))
                return Instantiate(SettingsWindowPath,_root).GetComponent<TWindow>();
            else if (typeof(TWindow) == typeof(LevelsWindow))
                return Instantiate(LevelsWindowPath,_root).GetComponent<TWindow>();

            throw new InvalidOperationException();
        }

        public void CreateRoot()
        {
            _root = Instantiate(RootPath).GetComponent<Transform>();
        }

        private Object Instantiate(string path)
        {
            return Object.Instantiate(Resources.Load(path));
        }

        private Object Instantiate(string path, Transform parent)
        {
            return Object.Instantiate(Resources.Load(path), parent);
        }
    }
}