using UnityEngine;

namespace Skin.Source.Modules.Skin.Scripts
{
    [CreateAssetMenu(fileName = "Skin", menuName = "Skins/Skin", order = 0)]
    public class Skin : ScriptableObject
    {
        [SerializeField] private Sprite _prefab;
        [Min(0)][SerializeField] private int _price;

        private bool _isOpen;
        
        public Sprite Prefab => _prefab;
        public int Price => _price;
        public bool IsOpen => _isOpen;

        public bool TryOpen(int value)
        {
            if (value > _price)
                return _isOpen = true;

            return _isOpen;
        }
    }
}