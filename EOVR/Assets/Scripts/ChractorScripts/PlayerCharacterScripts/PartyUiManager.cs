using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyUiManager : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject menu_Item;
    public GameObject menu_Skill;
    public GameObject menu_Status;
    public GameObject menu_Custom;
    public GameObject menu_Party;
    public GameObject CharacterStatue;
    public GameObject[] positionArray = new GameObject[6];

    static PartyUiManager _instance;
    public static PartyUiManager instance
    {
        get { return _instance; }
    }

    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        DontDestroyOnLoad(this);
    }

    public void PartyMenuActiveChange()
    {
        menu_Party.SetActive(!menu_Party.activeSelf);
    }
    public void ItemMenuActiveChange()
    {
        menu_Item.SetActive(!menu_Item.activeSelf);
    }
    public void SkillMenuActiveChange()
    {
        menu_Skill.SetActive(!menu_Skill.activeSelf);
    }
    public void StatusMenuActiveChange()
    {
        menu_Status.SetActive(!menu_Status.activeSelf);
    }
    public void CustomMenuActiveChange()
    {
        menu_Custom.SetActive(!menu_Custom.activeSelf);
    }
    public void MainMenuActiveChange()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);   
    }
    private void CharacterStatusActiveChange()
    {
        CharacterStatue.SetActive(!CharacterStatue.activeSelf);
    }

    

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetPosition();            
            MainMenuActiveChange();
            CharacterStatusActiveChange();
            for (int i = 0; i < positionArray.Length; i++)
            {
                positionArray[i].SetActive(true);
            }
        }
    }
    private void SetPosition()
    {
        List<PlayerCharacter> characterlist = PartyManager._instance.GetCharacterList();
        for (int i = 0; i < characterlist.Count; i++)
        {
            PlayerCharacter character = characterlist[i];
            switch (character.partyPosition)
            {
                case 1:
                    positionArray[0].GetComponent<CharacterStatusUI>().character = character;
                    break;
                case 2:
                    positionArray[1].GetComponent<CharacterStatusUI>().character = character;
                    break;
                case 3:
                    positionArray[2].GetComponent<CharacterStatusUI>().character = character;
                    break;
                case 4:
                    positionArray[3].GetComponent<CharacterStatusUI>().character = character;
                    break;
                case 5:
                    positionArray[4].GetComponent<CharacterStatusUI>().character = character;
                    break;
                case 6:
                    positionArray[5].GetComponent<CharacterStatusUI>().character = character;
                    break;
                default:
                    break;
            }
        } 
    }
    private void Start()
    {
        Debug.Log(PartyManager._instance.GetInventoryItemList().Count);
        Debug.Log(PartyManager._instance.GetInventoryItemList().Count);
        Debug.Log(PartyManager._instance.GetInventoryItemList().Count);
    }
}
