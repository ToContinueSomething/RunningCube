using System;
using UnityEngine;

namespace Skin.Source.Modules.Skin.Scripts
{
    public class SkinSelector : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Select(Sprite sprite)
        {
            if (sprite == null)
                throw new NullReferenceException(nameof(sprite));
            
            _spriteRenderer.sprite = sprite;
        }
    }
}
