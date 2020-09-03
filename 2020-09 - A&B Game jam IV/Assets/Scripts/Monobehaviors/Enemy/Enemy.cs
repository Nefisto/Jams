using UnityEngine;
using System.Reflection;

public partial class Enemy : MonoBehaviour
{
    public EnemyStatus blueprintStatus;

    [Header("Debug")]
    public Waypoints pathToFollow = null;    
    public EnemyStatus status;

    private void Start()
    {
        if (!blueprintStatus)
            Debug.LogError("This enemy does not have a blueprint status", this);

        status = ScriptableObject.CreateInstance<EnemyStatus>();
        ResetStatus();
    }

    //* PROUD 
    private void ResetStatus()
    {
        var myType = typeof(EnemyStatus);

        foreach (var field in myType.GetFields())
        {
            var currentValue = field.GetValue(blueprintStatus);
            field.SetValue(status, currentValue);
        }
    }
}