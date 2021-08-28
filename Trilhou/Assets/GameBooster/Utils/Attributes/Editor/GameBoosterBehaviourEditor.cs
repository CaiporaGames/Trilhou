using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

/// <summary>
/// Editor that adds Easy Buttons to all MonoBehaviour derived classes.
/// </summary>
namespace GameBooster
{

	// Custom inspector for MonoBehaviour including derived classes
	[CanEditMultipleObjects]
	[CustomEditor(typeof(GameBoosterBehaviour), true)]
    public class GameBoosterBehaviourEditor : Editor
    {

        ReorderableListHandler listHandler;

        private void OnEnable()
        {
            listHandler = new ReorderableListHandler();
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            //DrawHelpHeader();
            DrawProperties();

            DrawBottomButtons();
        }
        
        void DrawProperties()
        {
            EditorGUI.BeginChangeCheck();
            serializedObject.Update();

            var iterator = serializedObject.GetIterator();

            bool enterChildren = true;
            while (iterator.NextVisible(enterChildren))
            {
                
                bool isScriptProperty = iterator.propertyPath == "m_Script";
                using (new EditorGUI.DisabledScope(isScriptProperty))
                {
                    ReorderableList list;
                    if(listHandler.CheckProperty(iterator,out list))
                    {
                        list.DoLayoutList();
                    }
                    else
                    {
                        EditorGUILayout.PropertyField(iterator, true);
                    }
                }
                if (isScriptProperty)
                {
                    DrawHelpHeader();
                }

                enterChildren = false;
            }

            serializedObject.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
        }

        void DrawHelpHeader()
        {
            if (targets.Length == 1)
            {
                if (targets[0].GetType().GetCustomAttributes(typeof(CommentAttribute), true).Length > 0)
                {
                    var att = targets[0].GetType().GetCustomAttributes(typeof(CommentAttribute), true)[0] as CommentAttribute;

                    if (CommentAttribute.CanShowComments(targets[0].GetType()))
                    {
                        EditorGUILayout.HelpBox(att.text + "\n\n(Click to collapse)", MessageType.None);
                    }
                    else
                    {
                        EditorGUILayout.HelpBox(att.text.Split('\n')[0] + "  (Click to expand)", MessageType.None);
                    }

                    var rect = GUILayoutUtility.GetLastRect();
                    var guiColor = GUI.color;
                    GUI.color = Color.clear;
                    if (GUI.Button(rect, ""))
                    {
                        CommentAttribute.SwitchShowComments(targets[0].GetType());
                    }
                    GUI.color = guiColor;
                }
            }
        }

        void DrawBottomButtons()
        {
            if (targets.Length == 1)
            {

                // Loop through all methods with the Button attribute and no arguments
                foreach (var method in targets[0].GetType().GetMethods()
                    .Where(m => m.GetParameters().Length == 0)
                    .Where(m => m.GetCustomAttributes(typeof(ButtonAttribute), true).Length > 0)
                )
                {
                    var att = method.GetCustomAttributes(typeof(ButtonAttribute), true)[0] as ButtonAttribute;

                    bool canShowButton =
                        att.showType == ButtonAttribute.ShowType.EditorAndRuntime
                        ||
                        (att.showType == ButtonAttribute.ShowType.EditorOnly && !Application.isPlaying)
                        ||
                        (att.showType == ButtonAttribute.ShowType.RuntimeOnly && Application.isPlaying);

                    GUI.enabled = canShowButton;
                    if (GUILayout.Button(method.Name))
                    {
                        method.Invoke(targets[0], new object[0]);
                    }
                    GUI.enabled = true;
                }

                if (Application.isPlaying)
                {
                    foreach (var prop in targets[0].GetType().GetProperties()
                        .Where(p => p.CanRead)
                        .Where(p => p.GetCustomAttributes(typeof(InspectorDebuggerAttribute), true).Length > 0))
                    {

                        var att = prop.GetCustomAttributes(typeof(InspectorDebuggerAttribute), true)[0] as InspectorDebuggerAttribute;
                        var label = att.label != null ? att.label : prop.Name;

                        GUILayout.Label(label + ": " + prop.GetGetMethod().Invoke(targets[0], new object[0]));

                    }
                }

            }
        }

       
    }
}
