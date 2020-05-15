using UnityEngine;
using BBX.Main.Save.Models;

namespace BBX.Editor
{
    [UnityEditor.CustomEditor(typeof(SaveGame))]
    public class SaveGameEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var content = (SaveGame)target;
            
            GUILayout.Space(20);
            
            if(GUILayout.Button("Generate GUIDs"))
            {
                content.GenerateGuids();
            }
        }
    }
}