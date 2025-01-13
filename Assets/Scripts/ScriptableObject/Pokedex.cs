using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokedex", menuName = "Create Pokedex")]
public class Pokedex : SerializedScriptableObject
{
    public int pokedexId = 0;
    public int formId = 0;
    public Dictionary<Parameter, int> baseParam = CreateDictionary.CreateEnumIntDictionary<Parameter>();

    public List<PokemonType> typeList = new();
    public List<int> abilityIdList = new();

    public Sprite image = null;

    public PokemonGender pokemonGender = PokemonGender.Both;
    public AudioClip cry = null;

    public float weight = 0f;

    public bool willEvolve = false;
}
