using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameBooster{

	[CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
	public class ConditionalHidePropertyDrawer : PropertyDrawer {

		public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
		{
			ConditionalHideAttribute att = (ConditionalHideAttribute)attribute;
			bool show = GetAttributeResult (att, property);

			if (show) {
				EditorGUI.indentLevel += att.identation;
                EditorGUI.PropertyField (position, property, label, true);
                EditorGUI.indentLevel -= att.identation;
				GUI.depth -= 1;
			}
		}

		public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
		{
			ConditionalHideAttribute att = (ConditionalHideAttribute)attribute;
			bool enabled = GetAttributeResult (att, property);
			if (enabled) {
				return EditorGUI.GetPropertyHeight (property, label);
			} else {
				return -EditorGUIUtility.standardVerticalSpacing;
			}
		}

		private bool GetAttributeResult(ConditionalHideAttribute att, SerializedProperty property){
			bool enabled = true;

			for (int i = 0; i < att.conditionalSourceFields.Length; i++) {
				enabled &= GetAttributeResult (att, property, att.conditionalSourceFields [i]);
			}
			
			return enabled;
		}
		private bool GetAttributeResult(ConditionalHideAttribute att, SerializedProperty property, string sourceField){
			bool enabled = true;
			string propPath = property.propertyPath;
			string condPath = propPath.Replace (property.name, sourceField);
			SerializedProperty sourcePropValue = property.serializedObject.FindProperty (condPath);
			if (sourcePropValue != null) {
				enabled = sourcePropValue.boolValue;
			} else {
				Debug.LogWarning ("Property Not Found:" + sourceField);
			}
			if (att.inverseConditional) {
				enabled = !enabled;
			}
			return enabled;
		}

	}
}