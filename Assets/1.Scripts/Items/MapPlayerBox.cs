using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerBox : MapBlock, IBattle
{
    public MapTile myTile;
    public float curHP;

    private void Awake()
    {
        myTile = GetComponentInParent<MapTile>();
    }

    public bool IsLive
    {
        get => true;
    }

    public void OnDamage(float dmg)
    {
        curHP -= dmg;
    }
}
