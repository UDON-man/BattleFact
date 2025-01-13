using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class DataBase : MonoBehaviour
{
	private static DataBase _instance = null;

	void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
	}

	public static DataBase GetInstance()
	{
		return _instance;
	}

	public List<SkillEntity> skillEntities = new();
	public List<(int skillId, string skillName)> skillNameList = new();

	public static Dictionary<PokemonType, string> PokemonTypeJPNameDictionary = new()
	{
		{ PokemonType.Normal,"ノーマル" },
		{ PokemonType.Fire,"炎" },
		{ PokemonType.Water,"水" },
		{ PokemonType.Lightning,"電気" },
		{ PokemonType.Grass,"草" },
		{ PokemonType.Ice,"氷" },
		{ PokemonType.Fighting,"格闘" },
		{ PokemonType.Poison,"毒" },
		{ PokemonType.Land,"地面" },
		{ PokemonType.Fly,"飛行" },
		{ PokemonType.Psy,"エスパー" },
		{ PokemonType.Insect,"虫" },
		{ PokemonType.Rock,"岩" },
		{ PokemonType.Ghost,"ゴースト" },
		{ PokemonType.Dragon,"ドラゴン" },
		{ PokemonType.Dark,"悪" },
		{ PokemonType.Metal,"鋼" },
		{ PokemonType.Fairy,"フェアリー" },
	};

	[System.Serializable]
	public class TableBase<TKey, TValue, Type> where Type : KeyAndValue<TKey, TValue>
	{
		[SerializeField]
		private List<Type> list;
		private Dictionary<TKey, TValue> table;


		public Dictionary<TKey, TValue> GetTable()
		{
			if (table == null)
			{
				table = ConvertListToDictionary(list);
			}
			return table;
		}

		/// <summary>
		/// Editor Only
		/// </summary>
		public List<Type> GetList()
		{
			return list;
		}

		static Dictionary<TKey, TValue> ConvertListToDictionary(List<Type> list)
		{
			Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
			foreach (KeyAndValue<TKey, TValue> pair in list)
			{
				dic.Add(pair.Key, pair.Value);
			}
			return dic;
		}
	}

	/// <summary>
	/// Serializable KeyValuePair
	/// </summary>
	[System.Serializable]
	public class KeyAndValue<TKey, TValue>
	{
		public TKey Key;
		public TValue Value;

		public KeyAndValue(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
		public KeyAndValue(KeyValuePair<TKey, TValue> pair)
		{
			Key = pair.Key;
			Value = pair.Value;
		}
	}

	public class ParameterComparer : IEqualityComparer<object[]>
	{
		public virtual bool Equals(object[] i_lhs, object[] i_rhs)
		{
			return false;
		}

		public virtual int GetHashCode(object[] i_obj)
		{
			return 0;
		}

		#region select k elements from n different elements
		public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items, int k)
		{
			if (items.Count() < k)
			{
				k = items.Count();
			}

			if (k == 1)
			{
				foreach (var item in items)
				{
					yield return new T[] { item };
				}
				yield break;
			}
			foreach (var item in items)
			{
				var leftside = new T[] { item };
				var unused = items.Except(leftside);
				foreach (var rightside in Enumerate(unused, k - 1))
				{
					yield return leftside.Concat(rightside).ToArray();
				}
			}
		}
		#endregion
	}
}