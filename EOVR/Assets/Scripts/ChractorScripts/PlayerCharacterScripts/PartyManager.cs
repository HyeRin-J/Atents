using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerData;
using UnityEngine.SceneManagement;

public class PartyPlayer
{
    public int index = 0;
    public PlayerCharacter partyChar;

    public PartyPlayer(int _index, PlayerCharacter _char)
    {
        index = _index;
        partyChar = _char;
    }
}

public class PartyManager : MonoBehaviour
{
    public bool isFullGuard = false;        //full guard 사용 여부 변수
    public bool isAlter = false;            //alter 사용 여부 변수
    public int alterCount = 0;              //alter 데미지 증가 카운트 수

    public int poketMoney;
    public GameObject[] playableCharacter; //각 캐릭터 prefab을 담을 변수 0-swordman,1-dragoon,2-warrock,3-medic,4-bard  
    
    private int battleEntryNumber = 1;
    private List<int> conItem = new List<int>();
    private List<int> equipItem = new List<int>();
    private List<int> dropItem = new List<int>();
    private Dictionary<ITEMCATEGORY, List<int>> item = new Dictionary<ITEMCATEGORY, List<int>>();
    private List<PlayerCharacter> characters = new List<PlayerCharacter>();         //생성된 캐릭터를 담을 리스트
    
    Dictionary<int, List<PartyPlayer>> m_partyPlayerCharList = new Dictionary<int, List<PartyPlayer>>();

    List<PartyPlayer> m_partyPlayCharTemp = new List<PartyPlayer>();

    public void AddPartyTempChar(int _index, PlayerCharacter _char)
    {
        PartyPlayer find = m_partyPlayCharTemp.Find(delegate (PartyPlayer search)
        {
            return search.index == _index;
        });

        if (find == null)
        {
            m_partyPlayCharTemp.Add(new PartyPlayer(_index, _char));
            
        }
        else
        {
            find.partyChar = _char;
        }

        foreach (var _a in m_partyPlayCharTemp)
        {
            Debug.Log("index : " + _a.index + " : " + _a.partyChar.characterName);
        }

    }

    public void AddPartyChar( int _team, List<PartyPlayer> _list )
    {
        if (m_partyPlayerCharList.ContainsKey(_team) == false)
        {
            m_partyPlayerCharList.Add(_team, _list);
        }
        else
        {
            m_partyPlayerCharList[_team] = _list;
        }
    }

    public void AddPartyChar( int _team, int _index, PlayerCharacter _char )
    {
        List<PartyPlayer> _list = null;
        if ( m_partyPlayerCharList.ContainsKey( _team ) == false )
        {
            m_partyPlayerCharList.Add(_team, _list = new List<PartyPlayer>());
        }
        else
        {
            _list = m_partyPlayerCharList[_team];
        }

        PartyPlayer find = _list.Find(delegate (PartyPlayer search)
        {
            return search.index == _index;
        });

        if(find == null)
        {
            _list.Add(new PartyPlayer(_index, _char));
        }
        else
        {
            find.partyChar = _char;
        }

        foreach (var _a in _list)
        {
            Debug.Log("team : " + _team + " : " + _a.index + " : " + _a.partyChar.characterName);
        }
    }

    public List<PartyPlayer> GetPartyList( int _team )
    {
        if (m_partyPlayerCharList.ContainsKey(_team) == false)
        {
            return null;
        }

        return m_partyPlayerCharList[_team];        
    }

    public void SetPartyList(int _team)
    {
        m_partyPlayerCharList[_team] = m_partyPlayCharTemp;
    }

    //테스트용
    private int[] testItem = { 40001, 40002, 40011, 40005, 40009 };

    static PartyManager instance;
    public static PartyManager _instance
    {
        get { return instance; }
    }

    // Use this for initialization
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        GetComponent<SkillManager>().SetInstance();

        DontDestroyOnLoad(gameObject);

        TableMgr.Instance.CheckLoad();

        for (int i = 0; i < 5; i++)
        {
            CreateChracter(i);
        }
    }
    public void CreateChracter(int chractorNumber)
    {
        GameObject character = Instantiate(playableCharacter[chractorNumber], gameObject.transform);
        PlayerCharacter _char = character.GetComponent<PlayerCharacter>();
        characters.Add(_char);
        _char.LevelUp();

        if (battleEntryNumber < 6)
        {
            PlayerCharacter pc = character.GetComponent<PlayerCharacter>();
            pc.isParty = true;
            //pc.partyPosition = battleEntryNumber;
            pc.classType = chractorNumber;
            battleEntryNumber++;
        }
    }
    
    private void AddInventoryItem(List<int> list, int itemNumber, int itemAmount = 1)
    {
        
        for (int i = 0; i < itemAmount; i++)
        {
            list.Add(itemNumber);
        }
       
    }

    public void WarningOverItem()
    {
        //아이탬의 갯수가 최대치(60)를 초과할 떄 호출될 함수
    }

    public void DumpedItem(int itemNumber, int amount = 1)//아이템 버리기 
    {

        for (int i = 0; i < amount; i++)
        {
            if (10000 < itemNumber && itemNumber < 40000)
                equipItem.Remove(itemNumber);
            else if (40000 < itemNumber && itemNumber < 50000)
                conItem.Remove(itemNumber);
            else if (50000 < itemNumber && itemNumber < 60000)
                dropItem.Remove(itemNumber);

        }
    }
    public void ActiveRecuperate(PlayerCharacter _char)//캐릭터 휴양
    {
        PlayerCharacter _search = characters.Find(delegate (PlayerCharacter _find)
        {
            return _char == _find;
        });

        if (_search == null)
            return;

        _search.Recuperate();
    }

    public void Cancellation(PlayerCharacter _char)//캐릭터 말소
    {
        PlayerCharacter _search = characters.Find(delegate (PlayerCharacter _find)
        {
            return _char == _find;
        });

        if (_search == null)
            return;

        DestroyObject(_search.gameObject);
        characters.Remove(_search);
    }

    #region 파티확인
    public void GetCharacterIndex()//내가 편성한 파티 확인
    {
        foreach(var a in m_partyPlayCharTemp)
        {
            Debug.Log(a.partyChar.characterName);
        }

    }
    public void GetCharacter_Index()//`1~5번팀 팀원들 보기
    {
        for (int i = 0; i < 5; i++)
        {
            if (m_partyPlayerCharList.ContainsKey(i))
            {
                Debug.Log(i + ": ");
                foreach (var a in m_partyPlayerCharList[i])
                {
                    Debug.Log(a.partyChar.characterName + " ");
                }
                Debug.Log("\n");
            }            
        }
    }
    #endregion
    public void GetCharacter_Index(int i)//원하는 팀 팀원 보기
    {
        if (m_partyPlayerCharList.ContainsKey(i))
        {
            Debug.Log(i + ": ");
            foreach (var a in m_partyPlayerCharList[i])
            {
                Debug.Log(a.partyChar.characterName + " ");
            }
            Debug.Log("\n");
        }

    }


    #region Get
    public int GetItemAmount(int itemNumber)//해당 아이템의 수량 확인
    {
        List<int> checkedList = GetInventoryItemList(itemNumber);
        int amount = 0;

        for (int i = 0; i < checkedList.Count; i++)
        {
            if (itemNumber == checkedList[i])
                amount++;
        }

        return amount;
    }
    public List<int> GetInventoryItemList(int itemNumber)//특정 번호가 속한 리스트 반환
    {
        List<int> checkedList = new List<int>();
        if (10000 < itemNumber && itemNumber < 40000)
            checkedList = equipItem;
        else if (40000 < itemNumber && itemNumber < 50000)
            checkedList = conItem;
        else if (50000 < itemNumber && itemNumber < 60000)
            checkedList = dropItem;
        return checkedList;
    }
    public List<int> GetInventoryItemList()//모든 아이템 정보 반환
    {
        List<int> allList = new List<int>();
        for (int i = 0; i < conItem.Count; i++)
        {
            allList.Add(conItem[i]);
        }
        for (int i = 0; i < equipItem.Count; i++)
        {
            //Debug.Log(equipItem.Count);
            allList.Add(equipItem[i]);
        }       
        for (int i = 0; i < dropItem.Count; i++)
        {
            allList.Add(dropItem[i]);
        }
        
        allList.Sort();
        return allList;
    }
    public ConItemRecord GetItemRecord(int itemID)
    {
        return TableMgr.Instance.conItemTable.GetRecord(itemID);
    }
    public void GetLevelUpStat(GameObject chracter, CharacterData.CHARACTERCLASS characterClass, int level)
    {
        switch (characterClass)
        {
            case CharacterData.CHARACTERCLASS.SWORDMAN:
                level += 1000;
                break;
            case CharacterData.CHARACTERCLASS.DRAGOON:
                level += 2000;
                break;
            case CharacterData.CHARACTERCLASS.WARROCK:
                level += 3000;
                break;
            case CharacterData.CHARACTERCLASS.MEDIC:
                level += 4000;
                break;
            case CharacterData.CHARACTERCLASS.BARD:
                level += 5000;
                break;
        }
        Character_StatsRecord statsRecord = TableMgr.Instance.character_StatsTable.GetRecord(level);
        chracter.GetComponent<PlayerCharacter>().SetLevelUpStat
            (statsRecord.HP,
             statsRecord.TP,
             statsRecord.STR,
             statsRecord.INT,
             statsRecord.VIT,
             statsRecord.WIS,
             statsRecord.AGI,
             statsRecord.LUC);

    }
    public PlayerData.CharacterData.PLUSPROPERTY GetEquipProperty(int itemNumber, ITEMCATEGORY category)
    {
        CharacterData.PLUSPROPERTY property = new CharacterData.PLUSPROPERTY();
        switch (category)
        {
            case ITEMCATEGORY.WEAPON:
                property.pStats = TableMgr.Instance.weaponTable.GetRecord(itemNumber).wAtk;
                property.mStats = TableMgr.Instance.weaponTable.GetRecord(itemNumber).wMatk;
                property.plusProperty1 = TableMgr.Instance.weaponTable.GetRecord(itemNumber).wPlusProperty;
                property.plusValue1 = TableMgr.Instance.weaponTable.GetRecord(itemNumber).wPlusAmount;
                break;
            case ITEMCATEGORY.ARMOR:
                property.pStats = TableMgr.Instance.armorTable.GetRecord(itemNumber).aDef;
                property.mStats = TableMgr.Instance.armorTable.GetRecord(itemNumber).aMdef;
                property.plusProperty1 = TableMgr.Instance.armorTable.GetRecord(itemNumber).aPlusProperty;
                property.plusValue1 = TableMgr.Instance.armorTable.GetRecord(itemNumber).aPlusAmount;
                break;
            case ITEMCATEGORY.ACCESSORY:
                property.pStats = 0;
                property.mStats = 0;
                property.plusProperty1 = TableMgr.Instance.accessoryTable.GetRecord(itemNumber).acPlusProperty1;
                property.plusValue1 = TableMgr.Instance.accessoryTable.GetRecord(itemNumber).acPlusAmount1;
                property.plusProperty2 = TableMgr.Instance.accessoryTable.GetRecord(itemNumber).acPlusProperty2;
                property.plusValue2 = TableMgr.Instance.accessoryTable.GetRecord(itemNumber).acPlusAmount2;
                break;
        }
        return property;
    }
    public bool CheckAbleEquipment(CharacterData.CHARACTERCLASS characterClasss, int itemNumber)
    {
        if (itemNumber > 10000 && itemNumber < 20000)
        {
            WeaponRecord record = TableMgr.Instance.weaponTable.GetRecord(itemNumber);
            switch (characterClasss)
            {
                case CharacterData.CHARACTERCLASS.SWORDMAN:
                    if (record.wType == ITEMCATEGORY.Sword ||
                        record.wType == ITEMCATEGORY.Axe ||
                        record.wType == ITEMCATEGORY.Raiper)
                        return true;
                    else return false;
                case CharacterData.CHARACTERCLASS.DRAGOON:
                    if (record.wType == ITEMCATEGORY.Gun)
                        return true;
                    else return false;
                case CharacterData.CHARACTERCLASS.WARROCK:
                    if (record.wType == ITEMCATEGORY.staff ||
                        record.wType == ITEMCATEGORY.Gun)
                        return true;
                    else return false;
                case CharacterData.CHARACTERCLASS.MEDIC:
                    if (record.wType == ITEMCATEGORY.staff)
                        return true;
                    else return false;
                case CharacterData.CHARACTERCLASS.BARD:
                    if (record.wType == ITEMCATEGORY.Axe ||
                        record.wType == ITEMCATEGORY.Raiper)
                        return false;
                    else return true;
                default:
                    return false;
            }
        }
        else if (itemNumber > 20000 && itemNumber < 30000)
        {
            ArmorRecord record = TableMgr.Instance.armorTable.GetRecord(itemNumber);
            switch (characterClasss)
            {
                case CharacterData.CHARACTERCLASS.SWORDMAN:
                    if (record.aType == ITEMCATEGORY.Vest)
                        return false;
                    else return true;
                case CharacterData.CHARACTERCLASS.DRAGOON:
                    if (record.aType == ITEMCATEGORY.Vest)
                        return false;
                    else return true;
                case CharacterData.CHARACTERCLASS.WARROCK:
                    if (record.aType == ITEMCATEGORY.Vest)
                        return true;
                    else return false;
                case CharacterData.CHARACTERCLASS.MEDIC:
                    if (record.aType == ITEMCATEGORY.Heavy)
                        return false;
                    else return true;
                case CharacterData.CHARACTERCLASS.BARD:
                    if (record.aType == ITEMCATEGORY.Heavy)
                        return false;
                    else return true;
                default:
                    return false;
            }
        }
        else return false;



    }
    public int GetNeedExp(int level)
    {
        ExpRecord record = TableMgr.Instance.expTable.GetRecord(level);
        return record.EXP;
    }
    public List<PlayerCharacter> GetCharacterList()
    {
        return characters;
    }
    #endregion
    #region Set
    public void SetInventoryItem(int itemNumber, int itemAmount = 1)
    {
        ITEMCATEGORY inputItem;
        if (10000 < itemNumber && itemNumber < 40000)
            inputItem = ITEMCATEGORY.EQUIPITEM;
        else if (40000 < itemNumber && itemNumber < 50000)
            inputItem = ITEMCATEGORY.CONSUMEPTIONITEM;
        else if (50000 < itemNumber && itemNumber < 60000)
            inputItem = ITEMCATEGORY.DropItem;
        else
            return;
        switch (inputItem)
        {
            case ITEMCATEGORY.WEAPON:
            case ITEMCATEGORY.ARMOR:
            case ITEMCATEGORY.ACCESSORY:
            case ITEMCATEGORY.EQUIPITEM:
                AddInventoryItem(equipItem, itemNumber, itemAmount);
                break;
            case ITEMCATEGORY.CONSUMEPTIONITEM:
                AddInventoryItem(conItem, itemNumber, itemAmount);
                break;
            case ITEMCATEGORY.DropItem:
                AddInventoryItem(dropItem, itemNumber, itemAmount);
                break;
            default:
                break;
        }
        if (equipItem.Count + conItem.Count + dropItem.Count > 60)
            WarningOverItem();
    }
    #endregion    
}
