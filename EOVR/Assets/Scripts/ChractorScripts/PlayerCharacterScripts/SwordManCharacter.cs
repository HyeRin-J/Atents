using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using Skill;

public class SwordManCharacter : MonoBehaviour
{
    PlayerCharacter pc;
    
    public bool flameCharge = false;
    public float flameChargeRate = 0.0f;
    public bool iceCharge = false;
    public float iceChargeRate = 0.0f;
    public bool shockCharge = false;
    public float shockChargeRate = 0.0f;
    public bool tryCharge = false;
    public float tryChargeRate = 0.0f;
    public int heavyShockCount = 0;
    private void Start()
    {
        pc = gameObject.GetComponent<PlayerCharacter>();
        pc.characterName = "Slain";
        pc.characterClass = PlayerData.CharacterData.CHARACTERCLASS.SWORDMAN;
        pc.ChangeEquipment(10110, CharacterData.EQUIPMENTTYPE.WEAPON);
        pc.ChangeEquipment(20210, CharacterData.EQUIPMENTTYPE.ARMOR);
        pc.ChangeEquipment(20601, CharacterData.EQUIPMENTTYPE.SUBARMOR);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_PhysicalAttackBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_PhysicalAttackBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_PhysicalAttackBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_PhysicalAttackBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_RaisingEdge);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_HPBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_HPBoost);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_SwordMastery);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_SwordMastery);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_FlameCharge);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_IceCharge);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_ShockCharge);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_TryCharge);
        pc.SetLearnSkill((int)SKILLLIST.SwordMan_WarCry);
    }
    public void Reset()
    {
        flameCharge = false;
        flameChargeRate = 0.0f;
        iceCharge = false;
        iceChargeRate = 0.0f;
        shockCharge = false;
        shockChargeRate = 0.0f;
        tryCharge = false;
        tryChargeRate = 0.0f;
        heavyShockCount = 0;
}}
