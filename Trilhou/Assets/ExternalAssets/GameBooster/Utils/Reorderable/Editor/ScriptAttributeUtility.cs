using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;


public static class ScriptAttributeUtility
{
    public static FieldInfo GetFieldInfoFromProperty(SerializedProperty property, out Type type)
    {
        Type scriptTypeFromProperty = ScriptAttributeUtility.GetScriptTypeFromProperty(property);
        if (scriptTypeFromProperty == null)
        {
            type = null;
            return null;
        }
        return ScriptAttributeUtility.GetFieldInfoFromPropertyPath(scriptTypeFromProperty, property.propertyPath, out type);
    }
    public static Type GetScriptTypeFromProperty(SerializedProperty property)
    {
        SerializedProperty serializedProperty = property.serializedObject.FindProperty("m_Script");
        if (serializedProperty == null)
        {
            return null;
        }
        MonoScript monoScript = serializedProperty.objectReferenceValue as MonoScript;
        if ((UnityEngine.Object)monoScript == (UnityEngine.Object)null)
        {
            return null;
        }
        return monoScript.GetClass();
    }
    public static FieldInfo GetFieldInfoFromPropertyPath(Type host, string path, out Type type)
    {
        FieldInfo fieldInfo = null;
        type = host;
        string[] array = path.Split('.');
        for (int i = 0; i < array.Length; i++)
        {
            string text = array[i];
            if (i < array.Length - 1 && text == "Array" && array[i + 1].StartsWith("data["))
            {
                if (type.IsArrayOrList())
                {
                    type = type.GetArrayOrListElementType();
                }
                i++;
            }
            else
            {
                FieldInfo fieldInfo2 = null;
                Type type2 = type;
                while (fieldInfo2 == null && type2 != null)
                {
                    fieldInfo2 = type2.GetField(text, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    type2 = type2.BaseType;
                }
                if (fieldInfo2 == null)
                {
                    type = null;
                    return null;
                }
                fieldInfo = fieldInfo2;
                type = fieldInfo.FieldType;
            }
        }
        return fieldInfo;
    }
    public static List<PropertyAttribute> GetFieldAttributes(FieldInfo field)
    {
        if (field == null)
        {
            return null;
        }
        object[] customAttributes = field.GetCustomAttributes(typeof(PropertyAttribute), true);
        if (customAttributes != null && customAttributes.Length > 0)
        {
            return new List<PropertyAttribute>(from e in customAttributes
                                               select e as PropertyAttribute into e
                                               orderby -e.order
                                               select e);
        }
        return null;
    }
}