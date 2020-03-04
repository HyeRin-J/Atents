using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerData;

public class CharacterStatusUI : MonoBehaviour {
    public Text level;
    public Text characterName;
    public Text hpText;
    public Text tpText;
    public Image hpImage;
    public Image tpImage;

    //[HideInInspector]
    //public GameObject character = null;
    [HideInInspector]
    public PlayerCharacter character = null;

    private void OnEnable()
    {
        if(character == null)
        {
            gameObject.SetActive(false);
            return;
        }
        PlayerCharacter pc = character;// character.GetComponent<PlayerCharacter>(); //kij
        PlayerData.CharacterData.Stats stats = pc.GetCharacterStats();
        level.text = string.Format("{0}", pc.level);
        characterName.text = pc.characterName;
        hpText.text = string.Format("{0}", stats.MAXHP);//hpText.text = string.Format("{0}/{1}", pc.currentHp, stats.MAXHP );
        tpText.text = string.Format("{0}", stats.MAXTP);
        hpImage.fillAmount = (float)pc.currentHp / (float)stats.MAXHP;
        tpImage.fillAmount = (float)pc.currentTp / (float)stats.MAXTP;
    }

}
