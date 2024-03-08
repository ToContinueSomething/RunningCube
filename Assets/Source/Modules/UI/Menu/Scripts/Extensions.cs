using System.Collections.Generic;
using UnityEngine;

namespace Source.Modules.UI.Menu.Scripts
{
    public static class Extensions
    {
        public static void SetState(this CanvasGroup canvasGroup, bool state)
        {
            canvasGroup.alpha = state ? 1f : 0f;
            canvasGroup.interactable = state;
            canvasGroup.blocksRaycasts = state;
        }

        public static void EnableOneAndDisableOthers(this List<CanvasGroup> canvasGroups, CanvasGroup targetCanvas)
        {
            foreach (var canvasGroup in canvasGroups)
            {
                canvasGroup.SetState(canvasGroup == targetCanvas);
            }
        }
    }
}