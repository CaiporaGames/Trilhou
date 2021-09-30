using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EditorExtensionMethods
{
    // Public reimplmentation of extention methods and helpers that are marked internal in UnityEditor.dll

    public static bool IsArrayOrList(this Type listType)
    {
        return listType.IsArray || (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(List<>));
    }

    public static Type GetArrayOrListElementType(this Type listType)
    {
        if (listType.IsArray)
        {
            return listType.GetElementType();
        }
        if (listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(List<>))
        {
            return listType.GetGenericArguments()[0];
        }

        return null;
    }
}