using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;
using System.Linq;
using System.Reflection;
using System;

namespace GameBooster
{

    public class ReorderableListHandler
    {
        Dictionary<string, ReorderableList> dict;

        public ReorderableListHandler()
        {
            dict = new Dictionary<string, ReorderableList>();
        }

        private bool IsReorderable(SerializedProperty prop)
        {
            System.Type type = null;
            var field = ScriptAttributeUtility.GetFieldInfoFromProperty(prop, out type);
            var atts = ScriptAttributeUtility.GetFieldAttributes(field);

            if (atts != null)
            {
                for (int i = 0; i < atts.Count; i++)
                {
                    var att = atts[i];
                    if (att is ReorderableAttribute)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckProperty(SerializedProperty prop, out ReorderableList resultList)
        {
            if (prop.isArray)
            {
                if (!dict.ContainsKey(prop.propertyPath))
                {
                    if (IsReorderable(prop))
                    {
                        resultList = CreateList(prop.Copy());
                        dict[prop.propertyPath] = resultList;
                        return true;
                    }
                    else
                    {
                        resultList = null;
                        dict[prop.propertyPath] = null;
                        return false;
                    }
                }
                else
                {
                    resultList = dict[prop.propertyPath];
                    return resultList != null;
                }
            }
            else
            {
                resultList = null;
                return false;
            }
        }

        private ReorderableList CreateList(SerializedProperty prop)
        {
            var list = new ReorderableList(prop.serializedObject, prop, true, true, true, true);

            //list.onCanAddCallback = (ReorderableList _list) => { return prop.isExpanded; };
            //list.onCanRemoveCallback = (ReorderableList _list) => { return prop.isExpanded; };

            list.drawHeaderCallback = (Rect rect) =>
            {
                rect.x += 10;
                prop.isExpanded = EditorGUI.Foldout(rect, prop.isExpanded, prop.displayName);

                list.displayAdd = prop.isExpanded;
                list.displayRemove = prop.isExpanded;
                //list.onCanAddCallback

                //EditorGUI.LabelField(rect, prop.displayName);
            };
            
            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                if (!prop.isExpanded)
                    return;

                var element = prop.GetArrayElementAtIndex(index);

                bool singleLine = !element.hasVisibleChildren;

                if (singleLine)
                {
                    rect.y += 1;
                    rect.height = EditorGUIUtility.singleLineHeight;
                }
                else
                {
                    rect.x += 10;
                    rect.width -= 10;
                }

                if (singleLine)
                {
                //EditorGUI.PropertyField(rect, element, GUIContent.none);
                EditorGUI.PropertyField(rect, element, true);
                }
                else
                {
                    EditorGUI.PropertyField(rect, element, true);
                }
            };

            list.elementHeightCallback = (int index) =>
            {
                if (!prop.isExpanded)
                    return 0;

                var element = prop.GetArrayElementAtIndex(index);
                bool singleLine = !element.hasVisibleChildren;
                if (singleLine)
                    return EditorGUIUtility.singleLineHeight + 2 * EditorGUIUtility.standardVerticalSpacing;
                else
                    return EditorGUI.GetPropertyHeight(element);
            };

            return list;
        }

    }
}