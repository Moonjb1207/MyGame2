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
        InventoryManager.Instance.myInven.AddItems(EquipmentManager.Instance.weaponData.getEquipName(rnd), ItemType.weapon);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.weaponData.getEquipName(rnd), ItemType.weapon);
        tapContainer.tapPanels[(int)ItemType.weapon].isUpdated = false;
    }

    public void BuyEquipArmor()
    {
        int rnd = Random.Range(1, EquipmentManager.Instance.armorData.armorStats.Length);
        InventoryManager.Instance.myInven.AddItems(EquipmentManager.Instance.armorData.getEquipName(rnd), ItemType.armor);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.armorData.getEquipName(rnd), ItemType.armor);
        tapContainer.tapPanels[(int)ItemType.armor].isUpdated = false;
    }

    public void BuyEquipHelmet()
    {
        int rnd = Random.Range(1, EquipmentManager.Instance.helmetData.helmetStats.Length);
        InventoryManager.Instance.myInven.AddItems(EquipmentManager.Instance.helmetData.getEquipName(rnd), ItemType.helmet);

        gameObject.SetActive(false);
        result.ShowResult(EquipmentManager.Instance.helmetData.getEquipName(rnd), ItemType.helmet);
        tapContainer.tapPanels[(int)ItemType.helmet].isUpdated = false;
    }

}
