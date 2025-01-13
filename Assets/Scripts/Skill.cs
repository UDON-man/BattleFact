using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Skill
{
	SkillEntity _skillEntity = null;
	string _skillName = "";
	int _pp = 0;
	public Skill(SkillEntity skillEntity, string skillName)
	{
		if (skillEntity == null)
		{
			return;
		}

		_skillEntity = skillEntity;
		_skillName = skillName;
		_pp = skillEntity.maxPP;
	}
	public SkillEntity SkillEntity => _skillEntity;
	public string SkillName => _skillName;
	public int PP { get => _pp; set => _pp = value; }
}