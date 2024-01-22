using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace com.Klazapp.Editor
{
    [Serializable]
    public class InspectorViewHandlerComponent
    {
        internal Color32 pointerHoverColor = new Color32(175, 135, 54, 255);
        internal Color32 pointerDownColor = new Color32(75, 135, 54, 255);
        internal Color32 pointerUpColor = new Color32(44, 35, 44, 255);

        internal bool pointerDown;
        internal bool pointerUp;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Color32 GetColorByClickState(bool pointerIsDown, bool pointerIsUp)
        {
            return pointerIsDown ? pointerDownColor : pointerUpColor;
        }
    }
}