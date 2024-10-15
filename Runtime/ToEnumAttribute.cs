using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class ToEnumAttribute : PropertyAttribute
{
	public Type EnumType { get; }

	public ToEnumAttribute(Type enumType)
	{
		if (enumType.IsEnum == false)
			throw new InvalidOperationException($"The provided type '{enumType.FullName}' is not an enum type. Please provide a valid enum type.");
		EnumType = enumType;
	}
}