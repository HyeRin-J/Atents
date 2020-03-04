using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum Type
    {
        Equipable,
        Consumable,
        Material,
        Etc,
    }
    public int itemID;
    public string itemName;
    public Type type = Type.Etc;
}

public class InventoryManager : MonoBehaviour {
    public Dictionary<int, Item> inventory = new Dictionary<int, Item>();

    static InventoryManager _instance;
    public static InventoryManager instance
    {
        get { return _instance; }
    }

    private void OnEnable()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;

        Item item = new Item();
        item.itemID = 1001;
        item.type = Item.Type.Consumable;
        item.itemName = "회복약";
        inventory.Add(item.itemID, item);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
