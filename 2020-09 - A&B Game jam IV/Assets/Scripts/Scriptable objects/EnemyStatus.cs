using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "2020-09 - A&B Game jam IV/Enemy Status", order = 0)]
public class EnemyStatus : ScriptableObject
{
    [MinMaxRange(1, 30)]
    public IntRange initialLife;

    [MinMaxRange(1, 30)]
    public FloatRange initialSpeed;

    public int damage = 1;

    [HideInInspector] public int life;
    [HideInInspector] public float speed;
}