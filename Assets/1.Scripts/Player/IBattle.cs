using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattle
{
    public void OnDamage(float dmg);
    public void AddExp(int exp);
    public void AddGold(int gold);

    public bool IsLive
    {
        get;
    }
}
