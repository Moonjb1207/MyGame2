using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimEvent : MonoBehaviour
{
    public UnityEvent Bomb = null;
    public UnityEvent Death = null;

    public void Dying()
    {
        Death?.Invoke();
    }

    public void OnBomb()
    {
        Bomb?.Invoke();
    }
}
