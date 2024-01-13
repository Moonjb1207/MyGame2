using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEquipmentContainer : MonoBehaviour
{
    public List<ItemSelect> items = new List<ItemSelect>();
    public ItemSelect selectItem;
    public ItemType itemType;


    private void Awake()
    {
        ItemSelect[] itemsarr = GetComponentsInChildren<ItemSelect>(true);

        for (int i = 0; i < itemsarr.Length; i++)
        {
            items.Add(itemsarr[i]);
        }
    }

    private void OnEnable()
    {
        LoadEquipment(itemType);
    }

    public void LoadEquipment(ItemType curindex)
    {
        if (curindex == ItemType.weapon)
        {
            List<string> showItems = InventoryManager.Instance.myInven.showWeapons();

            if (showItems.Count < items.Count)
            {
                for (int i = 0; i < showItems.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = showItems.Count; i < items.Count; i++)
                {
                    items[i].gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = items.Count; i < showItems.Count; i++)
                {
                    items.Add(Instantiate(selectItem));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.weapon);
                }
            }
        }
        else if (curindex == ItemType.armor)
        {
            List<string> showItems = InventoryManager.Instance.myInven.showArmors();

            if (showItems.Count < items.Count)
            {
                for (int i = 0; i < showItems.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = showItems.Count; i < items.Count; i++)
                {
                    items[i].gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = items.Count; i < showItems.Count; i++)
                {
                    items.Add(Instantiate(selectItem));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.armor);
                }
            }
        }
        else if (curindex == ItemType.helmet)
        {
            List<string> showItems = InventoryManager.Instance.myInven.showHelmets();

            if (showItems.Count < items.Count)
            {
                for (int i = 0; i < showItems.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = showItems.Count; i < items.Count; i++)
                {
                    items[i].gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    items[i].setMyName(showItems[i]);
                    items[i].gameObject.SetActive(true);
                }
                for (int i = items.Count; i < showItems.Count; i++)
                {
                    items.Add(Instantiate(selectItem));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.helmet);
                }
            }
        }
    }
}
