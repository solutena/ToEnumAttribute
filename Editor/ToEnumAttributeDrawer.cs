using System;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ToEnumAttribute))]
public class ToEnumAttributeDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		if (property.propertyType == SerializedPropertyType.String)
			DrawEnumPopup(position, property, label);
		else if (property.propertyType == SerializedPropertyType.Generic && property.isArray)
			DrawArray(position, property, label);
		else
			DrawError(position, property, label);
	}

	void DrawArray(Rect position, SerializedProperty property, GUIContent label)
	{
		for (int i = 0; i < property.arraySize; i++)
		{
			SerializedProperty element = property.GetArrayElementAtIndex(i);
			Rect elementRect = new(position.x, position.y + i * EditorGUIUtility.singleLineHeight, position.width, EditorGUIUtility.singleLineHeight);
			DrawEnumPopup(elementRect, element, label);
		}
	}

	void DrawEnumPopup(Rect position, SerializedProperty property, GUIContent label)
	{
		string enumString = property.stringValue;
		ToEnumAttribute stringToEnumAttribute = (ToEnumAttribute)attribute;
		Type enumType = stringToEnumAttribute.EnumType;

		if (Enum.TryParse(enumType, enumString, out object enumValue) == false)
			enumValue = Enum.GetValues(enumType).GetValue(0);

		EditorGUI.BeginChangeCheck();
		enumValue = EditorGUI.EnumPopup(position, label, (Enum)enumValue);
		if (EditorGUI.EndChangeCheck())
			property.stringValue = enumValue.ToString();
	}

	void DrawError(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.PropertyField(position, property, label, true);
		position.y += EditorGUIUtility.singleLineHeight;
		position.height = EditorGUIUtility.singleLineHeight;
		EditorGUI.HelpBox(position, "ToEnumAttribute only supports String type", MessageType.Warning);
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		if (property.propertyType == SerializedPropertyType.String)
			return base.GetPropertyHeight(property, label);
		else if (property.propertyType == SerializedPropertyType.Generic && property.isArray)
			return property.arraySize * EditorGUIUtility.singleLineHeight;
		else
			return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight;
	}
}