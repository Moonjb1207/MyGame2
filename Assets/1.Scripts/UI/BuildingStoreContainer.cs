using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStoreContainer : MonoBehaviour
{
    public List<BuildingBuy> buildings = new List<BuildingBuy>();
    public BuildingBuy buildingBuy;

    private void Awake()
    {
        BuildingBuy[] buildingsarr = GetComponentsInChildren<BuildingBuy>(true);

        for (int i = 0; i < buildingsarr.Length; i++)
        {
            buildings.Add(buildingsarr[i]);
        }
    }

    private void OnEnable()
    {
        LoadBuilding();
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadBuilding();
    }

    public void LoadBuilding()
    {
        if (InventoryManager.Instance == null)
            return;

        List<string> showBuildings = new List<string>();
        for(int i = 0; i < EquipmentManager.Instance.buildingData.buildingStats.Length; i++)
        {
            if (InventoryManager.Instance.mybuildingDic.ContainsKey
                (EquipmentManager.Instance.buildingData.buildingStats[i].buildingName))
                continue;

            showBuildings.Add(EquipmentManager.Instance.buildingData.buildingStats[i].buildingName);
        }

        if (showBuildings.Count < buildings.Count)
        {
            for (int i = 0; i < showBuildings.Count; i++)
            {
                buildings[i].setMyBuilding(showBuildings[i]);
                buildings[i].gameObject.SetActive(true);
            }
            for (int i = showBuildings.Count; i < buildings.Count; i++)
            {
                buildings[i].gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < buildings.Count; i++)
            {
                buildings[i].setMyBuilding(showBuildings[i]);
                buildings[i].gameObject.SetActive(true);
            }
            for (int i = buildings.Count; i < showBuildings.Count; i++)
            {
                buildings.Add(Instantiate(buildingBuy));
                buildings[i].setMyBuilding(showBuildings[i]);
            }
        }
    }
}
