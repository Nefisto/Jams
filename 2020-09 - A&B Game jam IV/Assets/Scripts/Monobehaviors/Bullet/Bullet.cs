using System.Collections;
using UnityEngine;

public class Bullet : LazyBehavior
{
    public float speed;

    private Coroutine followRoutine = null;
    private Enemy targetEnemy;

    private void SetEnemy(Enemy enemy)
    {
        targetEnemy = enemy;
        targetEnemy.onDie += Explode;
    }

    private void UnsetEnemy()
    {
        if (followRoutine == null)
            throw new System.Exception("Bullet exist but isn't following");

        StopCoroutine(followRoutine);

        targetEnemy.onDie -= Explode;
    }

    public void StartFollowTarget(Enemy enemy)
    {
        SetEnemy(enemy);

        followRoutine = StartCoroutine(FollowRoutine());

        IEnumerator FollowRoutine()
        {
            while (true)
            {
                var dist = (Vector2)(enemy.transform.position - transform.position);
                var dir = dist.normalized;

                if (dist.sqrMagnitude < .05f)
                {
                    Explode();

                    break;
                }

                var angle = dir.ToDegreeAngle();
                transform.eulerAngles = new Vector3(0f, 0f, angle);
                
                dir = dir * Time.deltaTime * speed;
                
                transform.Translate(dir, Space.World);

                yield return null;
            }
        }
    }

    public void Explode()
    {
        UnsetEnemy();

        animator.SetTrigger("Die");
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}