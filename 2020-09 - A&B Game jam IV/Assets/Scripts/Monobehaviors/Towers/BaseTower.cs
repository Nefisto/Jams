using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTower : LazyBehavior
{
    [Header("Editor only")]
    public Color32 wireFrameColor = Color.white;

    // public float range = 3f;

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = wireFrameColor;
    //     Gizmos.DrawWireSphere(transform.position, range);
    // }
}
