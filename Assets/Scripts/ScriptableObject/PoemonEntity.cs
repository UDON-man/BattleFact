using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PokemonEntity", menuName = "Create Pokemon")]
public class PokemonEntity : SerializedScriptableObject
{
	public string PokemonName = "";
	public string ItemName = "";
	public string AbilityName = "";

	public Dictionary<Parameter, int> Effort = CreateDictionary.CreateEnumIntDictionary<Parameter>();
	public Dictionary<NatureRevision, Parameter> NatureRevision = CreateDictionary.CreateEnumParameterDictionary<NatureRevision>();
	public List<string> SkillNameList = new();
	public MezapaType MezapaType = null;
	public Pokedex pokedex = null;
	public bool slowest = false;

	public int Level => 100;

	public Dictionary<Parameter, int> Individual
	{
		get
		{
			if (MezapaType == null)
			{
				return CreateDictionary.CreateEnumIntDictionary<Parameter>(defaultValue: 31);
			}

			return MezapaType.IndividualIsOdd.ToDictionary(dict => dict.Key, dict =>
			{
				//	最遅
				if (dict.Key == Parameter.S && slowest)
				{
					return 0;
				}

				return dict.Value ? 31 : 30;
			});
		}
	}
}
