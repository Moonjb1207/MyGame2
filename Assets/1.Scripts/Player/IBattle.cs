using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattle
{
    public void OnDamage(float dmg);

    public bool IsLive
    {
        get;
    }
}
