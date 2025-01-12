using System;
using System.Collections.Generic;
using System.Linq;
public static class IEnumerableExtension
{
	#region Get random element from list
	public static IEnumerable<T> GetRandom<T>(this IEnumerable<T> list, int count)
	{
		var random = new System.Random();

		var indexList = new List<int>();
		for (int i = 0; i < list.ToList().Count; i++)
		{
			indexList.Add(i);
		}

		for (int i = 0; i < count; i++)
		{
			int index = random.Next(0, indexList.Count);
			int value = indexList[index];
			indexList.RemoveAt(index);
			yield return list.ToList()[value];
		}
	}
	#endregion

	#region Map
	public static List<U> map<T, U>(this List<T> list, Func<T, U> getElement)
	{
		return list.Select(x => getElement(x)).ToList();
	}

	public static U[] map<T, U>(this T[] array, Func<T, U> getElement)
	{
		return array.Select(x => getElement(x)).ToArray();
	}
	#endregion

	#region Filter
	public static List<T> filter<T>(this List<T> list, Func<T, bool> getElement)
	{
		return list.Where(x => getElement(x)).ToList();
	}

	public static T[] filter<T>(this T[] array, Func<T, bool> getElement)
	{
		return array.Where(x => getElement(x)).ToArray();
	}
	#endregion

	#region Some
	public static bool some<T>(this IEnumerable<T> list, Func<T, bool> getElement)
	{
		return list.Any(x => getElement(x));
	}
	#endregion

	#region Flat
	public static List<T> flat<T>(this List<List<T>> list)
	{
		return list.SelectMany(x => x).ToList();
	}

	public static T[] flat<T>(this T[][] array)
	{
		return array.SelectMany(x => x).ToArray();
	}
	#endregion

	#region Reduce
	public static T reduce<T>(this IEnumerable<T> list, Func<T, T, T> getResult)
	{
		return list.Aggregate(getResult);
	}
	#endregion

	#region Clone
	public static List<T> clone<T>(this List<T> list)
	{
		return list.map(x => x).ToList();
	}

	public static T[] cloneArray<T>(this T[] array)
	{
		return array.map(x => x).ToArray();
	}
	#endregion

	#region Every
	public static bool every<T>(this IEnumerable<T> list, Func<T, bool> getElement)
	{
		return list.All(x => getElement(x));
	}
	#endregion
}
