using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{ 
    private static MainPlayer instance;
    public static MainPlayer Instance => instance;

    public Transform bodyTr;

    [SerializeField] Weapon[] weapons;
    public Weapon curWeapon;

    [SerializeField] EquipArmor[] armors;
    [SerializeField] EquipHelmet[] helmets;
    public EquipArmor curArmor;
    public EquipHelmet curHelmet;


    private void Awake()
    {
        instance = this;

        bodyTr = transform.Find("P_Jungle_Charc");
    }

    // Start is called before the first frame update
    void Start()
    {
        EquipWeapon("knife");
        EquipArmor("none_armor");
        EquipHelmet("none_helmet");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EquipWeapon(string weaponName)
    {
        if (curWeapon != null)
            curWeapon.gameObject.SetActive(false);

        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].stat.weaponName.Equals(weaponName))
            {
                curWeapon = weapons[i];
                curWeapon.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void EquipArmor(string equipname)
    {
        if (curArmor != null)
            curArmor.gameObject.SetActive(false);

        for (int i = 0; i < armors.Length; i++)
        {
            if (armors[i].stat.equipName.Equals(equipname))
            {
                curArmor = armors[i];
                curArmor.gameObject.SetActive(true);
                break;
            }
        }
    }

    public void EquipHelmet(string equipname)
    {
        if (curHelmet != null)
            curHelmet.gameObject.SetActive(false);

        for (int i = 0; i < helmets.Length; i++)
        {
            if (helmets[i].stat.equipName.Equals(equipname))
            {
                curHelmet = helmets[i];
                curHelmet.gameObject.SetActive(true);
                break;
            }
        }
    }
}
