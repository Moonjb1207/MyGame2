using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance;
    public static WeaponManager Instance => instance;

    public WeaponData weaponData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
