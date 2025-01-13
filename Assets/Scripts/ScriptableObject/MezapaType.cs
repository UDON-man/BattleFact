using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "MezapaType", menuName = "Create Mezapa")]

public class MezapaType : SerializedScriptableObject
{
	[SerializeField] PokemonType _pokemonType = PokemonType.Normal;

	[SerializeField] Dictionary<Parameter, bool> _individualIsOdd = CreateDictionary.CreateEnumBoolDictionary<Parameter>();

	public PokemonType PokemonType => _pokemonType;

	public Dictionary<Parameter, bool> IndividualIsOdd => _individualIsOdd;
}