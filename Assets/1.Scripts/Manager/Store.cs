using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public StoreResult result;
    public TapContainer tapContainer;

    public void BuyWeapon()
    {
        int rnd = Random.Range(1, EquipmentManager.Instance.weaponData.weaponStats.Length);
        InventoryManager.Instance.AddItems(EquipmentManager.Instance.weaponData.weaponStats[rnd].weaponName, ItemType.weapon);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.weaponData.weaponStats[rnd].weaponName, ItemType.weapon);
    }

    public void BuyEquipArmor()
    {
        int rnd = Random.Range(1, EquipmentManager.Instance.armorData.armorStats.Length);
        InventoryManager.Instance.AddItems(EquipmentManager.Instance.armorData.armorStats[rnd].equipName, ItemType.armor);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.armorData.armorStats[rnd].equipName, ItemType.armor);
    }

    public void BuyEquipHelmet()
    {
        int rnd = Random.Range(1, EquipmentManager.Instance.helmetData.helmetStats.Length);
        InventoryManager.Instance.AddItems(EquipmentManager.Instance.helmetData.helmetStats[rnd].equipName, ItemType.helmet);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.helmetData.helmetStats[rnd].equipName, ItemType.helmet);
    }

}
