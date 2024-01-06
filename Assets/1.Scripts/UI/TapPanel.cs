using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPanel : MonoBehaviour
{
    public List<ItemSelect> items = new List<ItemSelect>();
    public ItemSelect selectItem;

    public bool isUpdated;

    private void Awake()
    {
        ItemSelect[] itemsarr = GetComponentsInChildren<ItemSelect>(true);

        isUpdated = false;

        for (int i = 0; i < itemsarr.Length; i++)
        {
            items.Add(itemsarr[i]);
        }
    }

    public void LoadEquipment(int curindex)
    {
        if (curindex == (int)ItemType.weapon)
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
                    items.Add(Instantiate(selectItem, transform.GetChild(0)));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.weapon);
                }
            }
        }
        else if (curindex == (int)ItemType.armor)
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
                    items.Add(Instantiate(selectItem, transform.GetChild(0)));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.armor);
                }
            }
        }
        else if (curindex == (int)ItemType.helmet)
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
                    items.Add(Instantiate(selectItem, transform.GetChild(0)));
                    items[i].setMyName(showItems[i]);
                    items[i].setMyType(ItemType.helmet);
                }
            }
        }

        isUpdated = true;
    }
}
