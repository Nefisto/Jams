using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public Waypoints path;

    public GameObject enemy;

    public List<bool> coroutineLockers;

    private bool VerifyLock()
        => coroutineLockers.Exists(x => x == true);

    public void Spawn()
    {
        Debug.Log(VerifyLock());
    }
}
