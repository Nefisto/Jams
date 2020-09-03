using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "2020-09 - A&B Game jam IV/Enemy Status", order = 0)]
public class EnemyStatus : ScriptableObject
{
    [MinMaxRange(1, 30)]
    public IntRange life;

    [MinMaxRange(1, 30)]
    public FloatRange speed;

    public int damage = 1;
}