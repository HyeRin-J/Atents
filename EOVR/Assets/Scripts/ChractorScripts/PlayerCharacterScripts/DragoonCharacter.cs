using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;

public class DragoonCharacter : MonoBehaviour
{

    public bool isGuardActivation;
    public delegate int preActiveGuard();
    public preActiveGuard guard;
   
    PlayerCharacter pc;
    private void Start()
    {
        pc = gameObject.GetComponent<PlayerCharacter>();
        pc.characterName = "Leonor";
        pc.characterClass = PlayerData.CharacterData.CHARACTERCLASS.DRAGOON;
        pc.ChangeEquipment(10601, CharacterData.EQUIPMENTTYPE.WEAPON);
        pc.ChangeEquipment(20101, CharacterData.EQUIPMENTTYPE.ARMOR);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_GunMount);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_LineGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_MaterialGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_CounterGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_DivideGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_FullGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_SoulGuard);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_DragonsProtection);
        pc.SetLearnSkill((int)SKILLLIST.Dragoon_HealGuard);
    }
}