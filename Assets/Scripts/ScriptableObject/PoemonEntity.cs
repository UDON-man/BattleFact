using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PokemonEntity", menuName = "Create Pokemon")]
public class PokemonEntity : SerializedScriptableObject
{
	public string pokemonName = "";
	public int itemId = 0;
	public int abilityId = 0;
	public Dictionary<Parameter, int> effort = CreateDictionary.CreateEnumIntDictionary<Parameter>();
	public Dictionary<NatureRevision, Parameter> natureRevision = CreateDictionary.CreateEnumParameterDictionary<NatureRevision>();
	public List<int> skillIdList = new();
	public MezapaType mezapaType = null;
	public Pokedex pokedex = null;
	public bool slowest = false;

	public int Level => 100;
	public Dictionary<Parameter, int> Individual
	{
		get
		{
			if (mezapaType == null)
			{
				return CreateDictionary.CreateEnumIntDictionary<Parameter>(defaultValue: 31);
			}

			return mezapaType.IndividualIsOdd.ToDictionary(dict => dict.Key, dict =>
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
