using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Pokemon
{
	PokemonEntity _pokemonEntity = null;
	Player _owner = null;

	public Pokemon(PokemonEntity pokemonEntity, Player owner)
	{
		_pokemonEntity = pokemonEntity;
		_owner = owner;
		HP = GetBaseParameter(Parameter.H);
		skills = pokemonEntity.skillIdList.map((skillId) =>
		{
			(int skillId, string skillName)? skillNameItem = DataBase.GetInstance().skillNameList.Find(item => item.skillId == skillId);

			SkillEntity skillEntity = DataBase.GetInstance().skillEntities.Find(item => item.skillId == skillId);

			return new Skill(skillEntity: skillEntity, skillName: skillNameItem?.skillName ?? "");
		});
	}

	public PokemonEntity PokemonEntity => _pokemonEntity;
	public Player Owner => _owner;
	public int HP = 0;
	public List<Skill> skills = new();
	public int GetBaseParameter(Parameter parameter)
	{
		if (parameter == Parameter.H)
		{
			return (PokemonEntity.pokedex.baseParam[parameter] * 2 + PokemonEntity.Individual[parameter] + PokemonEntity.effort[parameter] / 4) * PokemonEntity.Level / 100 + PokemonEntity.Level + 10;
		}

		return (int)(((PokemonEntity.pokedex.baseParam[parameter] * 2 + PokemonEntity.Individual[parameter] + PokemonEntity.effort[parameter] / 4) * PokemonEntity.Level / 100 + 5) * (
			new Func<float>(() =>
			{
				if (PokemonEntity.natureRevision[NatureRevision.Up] == parameter)
				{
					return 1.1f;
				}

				if (PokemonEntity.natureRevision[NatureRevision.Down] == parameter)
				{
					return 0.9f;
				}

				return 1;
			})()));
	}
}