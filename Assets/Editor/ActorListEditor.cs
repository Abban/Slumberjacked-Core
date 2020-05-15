using UnityEngine;
using BBX.Main.Level.Utilities;

namespace BBX.Editor
{
    [UnityEditor.CustomEditor(typeof(ActorList))]
    public class ActorListEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var actorList = (ActorList)target;
            
            GUILayout.Space(20);
            
            if(GUILayout.Button("Import Children"))
            {
                actorList.ImportChildren();
            }
        }
    }
}