using System;
using System.Collections.Generic;
using Source.Modules.Scene.Scripts;
using Source.Modules.UI.Button.Scripts;
using Source.Modules.UI.Window;
using UnityEngine;
using Window.Source.Modules.UI.Window;

namespace Source.Modules.UI.Menu.Scripts
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _menu;
        [SerializeField] private CanvasGroup _levelMap;
        [SerializeField] private CanvasGroup _skins;

        [SerializeField] private UIButton _levelMapButton;
        [SerializeField] private UIButton _skinsButton;
        [SerializeField] private List<UIButton> _backToMenuButtons;

        [SerializeField] private SceneLoader _sceneLoader;
        [SerializeField] private List<Level.Level> _levels;

        private List<CanvasGroup> _canvasGroups;

        private void Awake()
        {
            _canvasGroups = new List<CanvasGroup> {_menu, _levelMap, _skins};
        }

        private void OnEnable()
        {
            foreach (var level in _levels) 
                level.Clicked += OnLevelClicked;

            _levelMapButton.Clicked += OnLevelMapMapClicked;
            _skinsButton.Clicked += OnSkinsClicked;

            foreach (var backToMenuButton in _backToMenuButtons) 
                backToMenuButton.Clicked += OnBackToMenuClicked;

        }

        private void OnLevelClicked(string nameScene)
        {
            _sceneLoader.Load(nameScene);
        }

        private void OnDisable()
        {
            foreach (var level in _levels) 
                level.Clicked -= OnLevelClicked;

            _levelMapButton.Clicked -= OnLevelMapMapClicked;
            _skinsButton.Clicked -= OnSkinsClicked;
            
            foreach (var backToMenuButton in _backToMenuButtons) 
                backToMenuButton.Clicked -= OnBackToMenuClicked;
        }

        private void OnSkinsClicked()
        {
           _canvasGroups.EnableOneAndDisableOthers(_skins);
        }

        private void OnBackToMenuClicked()
        {
            _canvasGroups.EnableOneAndDisableOthers(_menu);
        }

        private void OnLevelMapMapClicked()
        {
            _canvasGroups.EnableOneAndDisableOthers(_levelMap);
        }
    }
}