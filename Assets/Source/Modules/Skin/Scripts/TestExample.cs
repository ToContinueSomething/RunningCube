using System;
using UnityEngine;

namespace Skin.Source.Modules.Skin.Scripts
{
    public class TestExample : MonoBehaviour
    {
        [SerializeField] private SkinSelector _skinSelector;
        [SerializeField] private Sprite _sprite;

        private void Start()
        {
            _skinSelector.Select(_sprite);
        }
    }
}