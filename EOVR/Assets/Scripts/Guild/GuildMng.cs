using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuildMng : MonoBehaviour
{
    //public GameObject slotObject;
    public GameObject characterSlot;
    
    public GameObject panel;
    public List<PlayerCharacter> characterList;
    public GameObject detailMenu;
    
    static GuildMng instance;
    public static GuildMng _instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        GuildCharacter();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GuildCharacter()
    {
        characterList = PartyManager._instance.GetCharacterList();
        AddCharacterSlot();
    }

    public void AddCharacterSlot()
    {
        Button btn;
        for (int i = 0; i < characterList.Count; i++)
        {
            PlayerCharacter player;

            player = Instantiate(characterSlot).GetComponent<PlayerCharacter>();
            btn = player.GetComponent<Button>();
            btn.onClick.AddListener(() => Select(player));
            player.GetComponentInChildren<Text>().text = characterList[i].GetComponent<PlayerCharacter>().characterName;

            player.transform.SetParent(panel.transform);
            player.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            player.transform.localPosition = new Vector3(0, 0, 0);
            player.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void Select(PlayerCharacter _player)
    {
        detailMenu.SetActive(true);      // 캐릭터 클릭시 휴양과 말소를 띄운다.    
        ButtonMng._instance.player = _player;
    }
}
