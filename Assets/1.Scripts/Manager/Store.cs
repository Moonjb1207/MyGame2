using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    int rnd;
    public StoreResult result;

    public void BuyWeapon()
    {
        rnd = Random.Range((int)ItemName.knife + 1, (int)ItemName.weaponEnd);
        InventoryManager.Instance.myInven.AddItems((ItemName)rnd);

        gameObject.SetActive(false);
        result.ShowResult((ItemName)rnd);
    }

    public void BuyEquipArmor()
    {
        rnd = Random.Range((int)ItemName.none_armor + 1, (int)ItemName.armorEnd);
        InventoryManager.Instance.myInven.AddItems((ItemName)rnd);

        gameObject.SetActive(false);
        result.ShowResult((ItemName)rnd);
    }

    public void BuyEquipHelmet()
    {
        rnd = Random.Range((int)ItemName.none_helmet + 1, (int)ItemName.helmetEnd);
        InventoryManager.Instance.myInven.AddItems((ItemName)rnd);

        gameObject.SetActive(false);
        result.ShowResult((ItemName)rnd);
    }

    public void Back()
    {

    }
}
