using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokedex", menuName = "Create Pokedex")]
public class Pokedex : SerializedScriptableObject
{
    public string DisplayName;

    public Dictionary<Parameter, int> Base = CreateDictionary.CreateEnumIntDictionary<Parameter>();

    public List<PokemonType> TypeList;
    public List<string> AbilityNameList;

    public Sprite Image;

    public int PokedexNo;

    public PokemonGender PokemonGender;
    public AudioClip Cry;

    public float Weight;

    public bool WillEvolve;

    public string PokemonName => string.IsNullOrEmpty(DisplayName) ? this.name : DisplayName;
}
