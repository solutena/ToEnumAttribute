using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class ToEnumAttribute : PropertyAttribute
{
	public Type EnumType { get; }

	public ToEnumAttribute(Type enumType)
	{
		if (enumType.IsEnum == false)
			throw new ArgumentException("EnumType parameter must be an enumerated type");
		EnumType = enumType;
	}
}

#if UNITY_EDITOR
[UnityEditor.CustomPropertyDrawer(typeof(ToEnumAttribute))]
public class SerializebleEnumAttributeDrawer : UnityEditor.PropertyDrawer
{
	bool Condition(UnityEditor.SerializedProperty property)
	{
		return property.propertyType == UnityEditor.SerializedPropertyType.String;
	}

	public override void OnGUI(Rect position, UnityEditor.SerializedProperty property, GUIContent label)
	{
		if (Condition(property) == false)
		{
			UnityEditor.EditorGUI.PropertyField(position, property, label, true);
			position.y += UnityEditor.EditorGUIUtility.singleLineHeight;
			position.height = UnityEditor.EditorGUIUtility.singleLineHeight;
			UnityEditor.EditorGUI.HelpBox(position, "ToEnumAttribute only supports String type", UnityEditor.MessageType.Warning);
			return;
		}

		string enumString = property.stringValue;
		ToEnumAttribute stringToEnumAttribute = (ToEnumAttribute)attribute;
		Type enumType = stringToEnumAttribute.EnumType;

		if(Enum.TryParse(enumType, enumString, out object enumValue) == false)
			enumValue = Enum.GetValues(enumType).GetValue(0);

		UnityEditor.EditorGUI.BeginChangeCheck();
		enumValue = UnityEditor.EditorGUI.EnumPopup(position, label, (Enum)enumValue);
		if (UnityEditor.EditorGUI.EndChangeCheck())
			property.stringValue = enumValue.ToString();
	}

	public override float GetPropertyHeight(UnityEditor.SerializedProperty property, GUIContent label)
	{
		if (Condition(property) == false)
			return base.GetPropertyHeight(property, label) + UnityEditor.EditorGUIUtility.singleLineHeight;
		return base.GetPropertyHeight(property, label);
	}
}
#endif