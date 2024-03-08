using System;
using Source.Modules.UI.Button.Scripts;
using UnityEngine;

namespace Source.Modules.UI.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private string _nameLoadScene;

        private UIButton _uiButton;
        
        public event Action<string> Clicked;
        
        private void Awake()
        {
            _uiButton = GetComponent<UIButton>();
        }

        private void OnEnable()
        {
            _uiButton.Clicked += OnClicked;
        }

        private void OnDisable()
        {
            _uiButton.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            Clicked?.Invoke(_nameLoadScene);
        }
    }
}