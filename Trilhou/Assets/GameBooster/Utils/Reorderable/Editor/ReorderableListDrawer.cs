using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace GameBooster
{

    [CustomPropertyDrawer(typeof(BaseReorderableList), true)]
    public class ReorderableListDrawer : PropertyDrawer
    {

        private Dictionary<string, ReorderableList> cachedLists = new Dictionary<string, ReorderableList>();

        private ReorderableList getList(SerializedProperty property, string displayName)
        {
            ReorderableList list = null;

            cachedLists.TryGetValue(property.propertyPath, out list);

            if (list == null)
            {
                list = new ReorderableList(property.serializedObject, property, true, true, true, true);
                list.drawHeaderCallback = (Rect rect) =>
                {
                    var oldLevel = EditorGUI.indentLevel;
                    EditorGUI.indentLevel = 0;
                    EditorGUI.LabelField(rect, displayName + " (" + property.arraySize + ")");
                    EditorGUI.indentLevel = oldLevel;
                };
                list.drawElementCallback = (rect, index, isActive, isFocused) =>
                {
                    using (var scope = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
                    {
                        EditorGUI.LabelField(rect, new GUIContent(index.ToString()));
                    }
                    rect.x += 15;
                    rect.width -= 15;

                    if (property.GetArrayElementAtIndex(index).isExpanded)
                    {
                        var oldColor = GUI.color;
                        GUI.color *= new Color(1, 1, 1, 0.5f);
                        GUI.Box(rect, GUIContent.none);
                        GUI.color = oldColor;

                        rect.width -= 10;
                    }

                    var element = property.GetArrayElementAtIndex(index);


                    if (element.hasVisibleChildren)
                    {
                        EditorGUI.indentLevel++;
                        EditorGUI.PropertyField(rect, element, true);
                        EditorGUI.indentLevel--;
                    }
                    else
                    {
                        int oldLevel = EditorGUI.indentLevel;

                        if (property.depth >= 2) EditorGUI.indentLevel = 0;

                        EditorGUI.PropertyField(rect, element, GUIContent.none);

                        if (property.depth >= 2) EditorGUI.indentLevel = 0;

                        EditorGUI.indentLevel = oldLevel;
                    }


                };
                list.elementHeightCallback = (int index) =>
                {
                    var element = property.GetArrayElementAtIndex(index);

                    var extra = 0;
                    if (element.isExpanded)
                        extra += 10;

                    return EditorGUI.GetPropertyHeight(element) + extra;
                };

                cachedLists[property.propertyPath] = list;
            }
            return list;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return getList(property.FindPropertyRelative("list"), property.displayName).GetHeight();
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            var listProperty = property.FindPropertyRelative("list");
            var list = getList(listProperty, property.displayName);

            if (property.depth > 0)
            {
                position = EditorGUI.IndentedRect(position);
            }

            list.DoList(position);
        }
    }

}