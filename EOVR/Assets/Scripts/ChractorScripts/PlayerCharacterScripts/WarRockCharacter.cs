using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;

public class WarRockCharacter : MonoBehaviour
{
    public bool isCompreesionSpell;         //압축술식 사용 여부
    public float CompressionSpellRate;      //압축술식 배율
    public bool isMultipleSpell;            //다단술식 사용 여부
    public float MultipleSpellRate;         //다단술식 배율
    public bool isLifeDrain;                //라이프 드레인 습득 여부
    public float LifeDrainRate;             //라이프 드레인 배율
    public bool isHighSpeedCasting;         //고속영창 사용 여부
    PlayerCharacter pc;
    private void Start()
    {
        pc = gameObject.GetComponent<PlayerCharacter>();
        pc.characterName = "Isolet";
        pc.characterClass = PlayerData.CharacterData.CHARACTERCLASS.WARROCK;
        pc.ChangeEquipment(10520, CharacterData.EQUIPMENTTYPE.WEAPON);
        pc.ChangeEquipment(20310, CharacterData.EQUIPMENTTYPE.ARMOR);
        pc.ChargeSkillReset();
        pc.SetLearnSkill((int)SKILLLIST.Warrock_FireBall);
        pc.SetLearnSkill((int)SKILLLIST.Warrock_IcecleLance);
        pc.SetLearnSkill((int)SKILLLIST.Warrock_Lighting);
        pc.SetLearnSkill((int)SKILLLIST.Warrock_WindStorm);
    }

    public void Reset()
    {
        isCompreesionSpell = false;
        isMultipleSpell = false;
        isLifeDrain = false;
        CompressionSpellRate = 0.0f;
        MultipleSpellRate = 0.0f;
        LifeDrainRate = 0.0f;
    }
}
