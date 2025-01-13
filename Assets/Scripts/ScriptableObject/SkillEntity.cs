using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Create Skill")]
public class SkillEntity : SerializedScriptableObject
{
	public int skillId = 0;
	public PokemonType skillType = PokemonType.Normal;
	public SkillStyle skillStyle = SkillStyle.Physics;
	public int power = 0;
	public int hit = 100;
	public int maxPP = 20;
	public int priority = 0;
	public int criticalRank;
	public bool isTouch;
	public bool isStaticDamage;
	public bool absoluteHit;
	public bool penetrateSubstitute;
	public bool penetrateDefense;
	public bool absoluteCritical;
	[TextArea] public string description;
	public string skillClassName = "";

	public string PowerText => skillStyle == SkillStyle.Change || power <= 0 ? "-" : power.ToString();
}
