using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICharacterList : MonoBehaviour
{
    public List<UICharSlot> slotList = new List<UICharSlot>();
    public Transform panel;
    public UICharSlot characterSlot;

    public void Open(List<PlayerCharacter> _list, UICharSlot.OnClickEvent _event )
    {
        for (int i = 0; i < slotList.Count; ++i)
        {
            if(slotList[i] == null)
            {
                continue;
            }
            GameObject.Destroy(slotList[i].gameObject);
        }

        slotList.Clear();
        gameObject.SetActive(true);
        for (int i = 0; i < _list.Count; ++i)
        {
            UICharSlot slot = Instantiate<UICharSlot>(characterSlot);
            slot.Open(i, _list[i], _event);
            slot.transform.SetParent(panel.transform);
            slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            slot.transform.localPosition = new Vector3(0, 0, 0);
            slot.transform.localRotation = new Quaternion(0, 0, 0, 0);

            slotList.Add(slot);
        }        
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void ListDestroy(UICharSlot _slot)
    {
        UICharSlot _search = slotList.Find(delegate (UICharSlot _findSlot) { return _findSlot == _slot; });
        if(_search == null)
        {
            return;
        }

        GameObject.Destroy(_slot.gameObject);
        slotList.Remove(_slot);
    }
}