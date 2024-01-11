using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimEvent : MonoBehaviour
{
    public UnityEvent Bomb = null;

    public void OnBomb()
    {
        Bomb?.Invoke();
    }
}
