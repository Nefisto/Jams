using UnityEngine;

public partial class Enemy
{
    private void Movement(Vector2 direction)
    {
        var newPos = direction * Time.deltaTime * status.speed.GetRandom();

        transform.Translate(newPos);
    }
}