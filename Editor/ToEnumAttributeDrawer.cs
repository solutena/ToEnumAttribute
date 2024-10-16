using System;
using UnityEngine;

namespace UnityEditor
{
	[CustomPropertyDrawer(typeof(ToEnumAttribute))]
	public class ToEnumAttributeDrawer : PropertyDrawer
	{
		bool Condition(SerializedProperty property)
		{
			return property.propertyType == SerializedPropertyType.String;
		}

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (Condition(property) == false)
			{
				EditorGUI.PropertyField(position, property, label, true);
				position.y += EditorGUIUtility.singleLineHeight;
				position.height = EditorGUIUtility.singleLineHeight;
				EditorGUI.HelpBox(position, "ToEnumAttribute only supports String type", MessageType.Warning);
				return;
			}

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

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (Condition(property) == false)
				return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight;
			return base.GetPropertyHeight(property, label);
		}
	}
}
