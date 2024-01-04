using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipInventory : MonoBehaviour
{
    public GameObject first;
    public List<ItemName> showItems = new List<ItemName>();
    public ItemSelect selectItem;

    public Store store;

    public List<ItemSelect> curItems = new List<ItemSelect>();

    public void LoadWeapon()
    {
        showItems = InventoryManager.Instance.myInven.showWeapons();

        if(curItems != null)
        {
            for(int i = 0; i < curItems.Count; i++)
            {
                Destroy(curItems[i].gameObject);
            }
            curItems.Clear();
        }

        for(int i = 0; i < showItems.Count; i++)
        {
            ItemSelect curitem = Instantiate(selectItem, first.transform);
            curitem.setMyName(showItems[i]);
            curItems.Add(curitem);
        }
    }

    public void LoadArmor()
    {
        showItems = InventoryManager.Instance.myInven.showArmors();

        if (curItems != null)
        {
            for (int i = 0; i < curItems.Count; i++)
            {
                Destroy(curItems[i].gameObject);
            }
            curItems.Clear();
        }

        for (int i = 0; i < showItems.Count; i++)
        {
            ItemSelect curitem = Instantiate(selectItem, first.transform);
            curitem.setMyName(showItems[i]);
            curItems.Add(curitem);
        }
    }

    public void LoadHelmet()
    {
        showItems = InventoryManager.Instance.myInven.showHelmets();

        if (curItems != null)
        {
            for (int i = 0; i < curItems.Count; i++)
            {
                Destroy(curItems[i].gameObject);
            }
            curItems.Clear();
        }

        for (int i = 0; i < showItems.Count; i++)
        {
            ItemSelect curitem = Instantiate(selectItem, first.transform);
            curitem.setMyName(showItems[i]);
            curItems.Add(curitem);
        }
    }

    public void GameStart()
    {
        InventoryManager.Instance.LoadScene();
        LoadManager.Instance.ChangeScene("PlayGame");
    }
}
