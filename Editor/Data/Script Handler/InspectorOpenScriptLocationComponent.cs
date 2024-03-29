using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace com.Klazapp.Editor
{
    [Serializable]
    public class InspectorOpenScriptLocationComponent
    {
        public Color32 pointerHoverColor = new Color32(175, 135, 54, 255);
        public Color32 pointerDownColor = new Color32(210, 210, 27, 255);
        public Color32 pointerUpColor = new Color32(44, 35, 44, 255);

        public bool pointerDown;
        public bool pointerUp;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Color32 GetColorByClickState(bool pointerIsDown, bool pointerIsUp)
        {
            return pointerIsDown ? pointerDownColor : pointerUpColor;
        }
    }
}