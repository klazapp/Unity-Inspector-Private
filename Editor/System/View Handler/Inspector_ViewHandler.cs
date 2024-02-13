using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace com.Klazapp.Editor
{
    public partial class Inspector
    {
        internal static InspectorViewHandlerModule inspectorViewHandlerModule;
        
        public Texture2D deselectedCustomViewIcon;
        public Texture2D deselectedClassicViewIcon;
        public Texture2D deselectedDebugViewIcon;
        
        public Texture2D selectedCustomViewIcon;
        public Texture2D selectedClassicViewIcon;
        public Texture2D selectedDebugViewIcon;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnCreatedViewHandler()
        {
            inspectorViewHandlerModule = new InspectorViewHandlerModule();
            inspectorViewHandlerModule.OnCreated();
            deselectedCustomViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Deselected Custom View Icon.png");
            deselectedClassicViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Deselected Classic View Icon.png");
            deselectedDebugViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Deselected Debug View Icon.png");
            selectedCustomViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Selected Custom View Icon.png");
            selectedClassicViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Selected Classic View Icon.png");
            selectedDebugViewIcon = AssetDatabase.LoadAssetAtPath<Texture2D>("Packages/com.Klazapp.inspector/Editor/Data/Textures/View Handlers/Selected Debug View Icon.png");
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void OnDisplayViewHandler()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginVertical();
            
            EditorGUILayout.BeginHorizontal(GUI.skin.box);

            EditorHelper.DrawBox(40, 40,
                inspectorViewHandlerModule.customViewComponent.GetColorByClickState(
                    inspectorViewHandlerModule.customViewComponent.pointerDown,
                    inspectorViewHandlerModule.customViewComponent.pointerUp), "",
                inspectorViewHandlerModule.viewContentStyle,
                InspectorViewHandlerModule.inspectorViewHandlerMode == InspectorViewHandlerMode.Custom
                    ? selectedClassicViewIcon
                    : deselectedClassicViewIcon);

            CheckCustomViewPointerState();
            
            EditorHelper.DrawSpace(50);
                
            EditorHelper.DrawBox(40, 40,
                inspectorViewHandlerModule.classicViewComponent.GetColorByClickState(
                    inspectorViewHandlerModule.classicViewComponent.pointerDown,
                    inspectorViewHandlerModule.classicViewComponent.pointerUp), "",
                inspectorViewHandlerModule.viewContentStyle,
                InspectorViewHandlerModule.inspectorViewHandlerMode == InspectorViewHandlerMode.Classic
                    ? selectedCustomViewIcon
                    : deselectedCustomViewIcon);
            
            CheckClassViewPointerState();
             
            EditorHelper.DrawSpace(50);
                
            EditorHelper.DrawBox(40, 40,
                inspectorViewHandlerModule.debugViewComponent.GetColorByClickState(
                    inspectorViewHandlerModule.debugViewComponent.pointerDown,
                    inspectorViewHandlerModule.debugViewComponent.pointerUp), "",
                inspectorViewHandlerModule.viewContentStyle,
                InspectorViewHandlerModule.inspectorViewHandlerMode == InspectorViewHandlerMode.Debug
                    ? selectedDebugViewIcon
                    : deselectedDebugViewIcon);
            
            CheckDebugViewPointerState();
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndVertical();
        }

        #region Check Pointers
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckCustomViewPointerState()
        {
            if (!inspectorViewHandlerModule.customViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.customViewComponent.pointerDown = EditorHelper.OnPointerDownInLastRect();
            }

            if (inspectorViewHandlerModule.customViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.customViewComponent.pointerUp = EditorHelper.OnPointerUpInLastRect();

                if (inspectorViewHandlerModule.customViewComponent.pointerUp)
                { 
                    inspectorViewHandlerModule.customViewComponent.pointerDown = false;
                    inspectorViewHandlerModule.customViewComponent.pointerUp = false;
                    
                    SwitchToCustomView();
                }
                
                Repaint();
            }

            if (!EditorHelper.OnPointerUp()) 
                return;
            
            if (!EditorHelper.OnPointerLeftRect())
                return;
                
            inspectorViewHandlerModule.customViewComponent.pointerDown = false;
            inspectorViewHandlerModule.customViewComponent.pointerUp = false;
                    
            Repaint();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckClassViewPointerState()
        {
            if (!inspectorViewHandlerModule.classicViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.classicViewComponent.pointerDown = EditorHelper.OnPointerDownInLastRect();
            }

            if (inspectorViewHandlerModule.classicViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.classicViewComponent.pointerUp = EditorHelper.OnPointerUpInLastRect();

                if (inspectorViewHandlerModule.classicViewComponent.pointerUp)
                { 
                    inspectorViewHandlerModule.classicViewComponent.pointerDown = false;
                    inspectorViewHandlerModule.classicViewComponent.pointerUp = false;
                    
                    SwitchToClassicView();
                }
                
                Repaint();
            }

            if (!EditorHelper.OnPointerUp()) 
                return;
            
            if (!EditorHelper.OnPointerLeftRect())
                return;
                
            inspectorViewHandlerModule.classicViewComponent.pointerDown = false;
            inspectorViewHandlerModule.classicViewComponent.pointerUp = false;
                    
            Repaint();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void CheckDebugViewPointerState()
        {
            if (!inspectorViewHandlerModule.debugViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.debugViewComponent.pointerDown = EditorHelper.OnPointerDownInLastRect();
            }

            if (inspectorViewHandlerModule.debugViewComponent.pointerDown)
            {
                inspectorViewHandlerModule.debugViewComponent.pointerUp = EditorHelper.OnPointerUpInLastRect();

                if (inspectorViewHandlerModule.debugViewComponent.pointerUp)
                { 
                    inspectorViewHandlerModule.debugViewComponent.pointerDown = false;
                    inspectorViewHandlerModule.debugViewComponent.pointerUp = false;
                    
                    SwitchToDebugView();
                }
                
                Repaint();
            }

            if (!EditorHelper.OnPointerUp()) 
                return;
            
            if (!EditorHelper.OnPointerLeftRect())
                return;
                
            inspectorViewHandlerModule.debugViewComponent.pointerDown = false;
            inspectorViewHandlerModule.debugViewComponent.pointerUp = false;
                    
            Repaint();
        }
        #endregion
        
        #region Switch Views
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwitchToCustomView()
        {
            InspectorViewHandlerModule.inspectorViewHandlerMode = InspectorViewHandlerMode.Custom;
            RestoreSkinProperties();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwitchToClassicView()
        {
            InspectorViewHandlerModule.inspectorViewHandlerMode = InspectorViewHandlerMode.Classic;
            RestoreSkinProperties();
        }
         
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SwitchToDebugView()
        {
            InspectorViewHandlerModule.inspectorViewHandlerMode = InspectorViewHandlerMode.Debug;
            RestoreSkinProperties();
        }
        #endregion
    }
}