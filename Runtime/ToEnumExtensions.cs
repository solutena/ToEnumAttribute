using System;

public static class ToEnumExtensions
{
	public static T ParseEnum<T>(this string enumName, T defaultValue = default) where T : struct, Enum
	{
		return Enum.TryParse(enumName, out T result) ? result : defaultValue;
	}
}