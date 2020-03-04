using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;
public class MedicCharacter : MonoBehaviour
{
    PlayerCharacter pc;
    public bool isOverHeal = true;
    public float OverHealRate;
    

    private void Start()
    {
        pc = gameObject.GetComponent<PlayerCharacter>();
        pc.characterName = "Teresa";
        pc.characterClass = PlayerData.CharacterData.CHARACTERCLASS.MEDIC;
        pc.ChangeEquipment(10501, CharacterData.EQUIPMENTTYPE.WEAPON);
        pc.ChangeEquipment(20301, CharacterData.EQUIPMENTTYPE.ARMOR);
        pc.SetLearnSkill((int)SKILLLIST.Medic_Healing);
        pc.SetLearnSkill((int)SKILLLIST.Medic_LineHeal);
        pc.SetLearnSkill((int)SKILLLIST.Medic_AntiBody);
        pc.SetLearnSkill((int)SKILLLIST.Medic_StarDrop);
        pc.SetLearnSkill((int)SKILLLIST.Medic_HeavyStrike);
        pc.SetLearnSkill((int)SKILLLIST.Medic_LastHeal);
        OverHealRate = 1.2f;
        isOverHeal = true;

    }
}
