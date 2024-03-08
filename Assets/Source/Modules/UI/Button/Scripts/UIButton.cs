using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.Modules.UI.Button.Scripts
{
    public class UIButton : MonoBehaviour,IPointerClickHandler
    {
        public event Action Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();  
        }
    }
}