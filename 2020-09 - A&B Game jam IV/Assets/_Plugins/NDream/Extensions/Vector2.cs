using UnityEngine;

public partial class Extensions
{
    public static Vector2Int ToVector2Int(this Vector2 vector2)
        => new Vector2Int(Mathf.RoundToInt(vector2.x), Mathf.RoundToInt(vector2.y));
}