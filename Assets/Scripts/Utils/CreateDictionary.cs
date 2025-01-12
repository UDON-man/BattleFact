using System.Collections.Generic;
using System;
using System.Linq;


public static class CreateDictionary
{
	public static Dictionary<T, int> CreateEnumIntDictionary<T>(int defaultValue = 0) where T : Enum
	{
		var values = Enum.GetValues(typeof(T));
		return values.OfType<T>().ToDictionary(value => value, _ => defaultValue);
	}

	public static Dictionary<T, bool> CreateEnumBoolDictionary<T>(bool defaultValue = false) where T : Enum
	{
		var values = Enum.GetValues(typeof(T));
		return values.OfType<T>().ToDictionary(value => value, _ => defaultValue);
	}

	public static Dictionary<T, Parameter> CreateEnumParameterDictionary<T>(Parameter defaultValue = Parameter.A) where T : Enum
	{
		var values = Enum.GetValues(typeof(T));
		return values.OfType<T>().ToDictionary(value => value, _ => defaultValue);
	}
}

