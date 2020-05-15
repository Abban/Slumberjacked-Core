using UnityEditor;
using UnityEngine;

namespace BBX.Editor
{
    [CustomEditor(typeof(CanvasGroup))]
    public class CanvasGroupEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var canvasGroup = (CanvasGroup)target;
            
            GUILayout.Space(20);
            
            if(GUILayout.Button("Toggle Visibility"))
            {
                if (canvasGroup.interactable)
                {
                    canvasGroup.alpha = 0;
                    canvasGroup.interactable = false;
                    canvasGroup.blocksRaycasts = false;
                }
                else
                {
                    canvasGroup.alpha = 1;
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                }
            }
        }
    }
}