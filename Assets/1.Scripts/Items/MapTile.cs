using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public MapBlock myChild;
    public MapPlayerBox myPBox;

    private void Awake()
    {
        myChild = GetComponentInChildren<MapBlock>();
    }

    public void CreateBox()
    {
        if (hasChild()) return;

        MapPlayerBox myBox = Instantiate(myPBox);
        myChild = myBox;
    }

    public bool hasChild()
    {
        if(myChild == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
