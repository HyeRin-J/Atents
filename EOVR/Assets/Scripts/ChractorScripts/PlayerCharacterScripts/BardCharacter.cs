using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;
public class BardCharacter : MonoBehaviour
{
    PlayerCharacter pc;
    private void Start()
    {
        pc = gameObject.GetComponent<PlayerCharacter>();
        pc.characterName = "Lisa";
        pc.characterClass = PlayerData.CharacterData.CHARACTERCLASS.BARD;
        pc.ChangeEquipment(10101, CharacterData.EQUIPMENTTYPE.WEAPON);
        pc.ChangeEquipment(20201, CharacterData.EQUIPMENTTYPE.ARMOR);
        pc.SetLearnSkill((int)SKILLLIST.Bard_SongMastery);
        pc.SetLearnSkill((int)SKILLLIST.Bard_ViolentBattleSong);
        pc.SetLearnSkill((int)SKILLLIST.Bard_HolyProtectionSong);
        pc.ChargeSkillReset();
    }
}