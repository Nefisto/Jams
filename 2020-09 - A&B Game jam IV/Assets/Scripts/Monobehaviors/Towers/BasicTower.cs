using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class BasicTower : BaseTower
{
    [Space(3), MinMaxRange(1, 10)]
    public IntRange damage;

    public float fireRate;

    public bool disabledAtack = false;

    public float range = 3f;

    // public enum State { Finding, Locked }
    public enum Kind { Single, Multiple}
    public Kind towerKind;
    public Enemy targetEnemy;

    [Header("Debug")]
    // public State currentState = State.Finding;
    public List<Enemy> enemiesInRange;

    public GameObject bulletPrefab;

    public void ResetStatus()
    {
        // currentState = State.Finding;

        circleCollider2D.radius = range;
    }

    private void Start()
    {
        ResetStatus();
    }

    public void AtackOneTarget()
    {
        if (!targetEnemy)
            return;

        if (disabledAtack)
            return;

        StartCoroutine(SingleAtackCoroutine());

        IEnumerator SingleAtackCoroutine()
        {
            while (enemiesInRange.Count != 0)
            {
                var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
                bullet.StartFollowTarget(targetEnemy);

                yield return new WaitForSeconds(fireRate);
            }
        }
    }

    public void AtackAllTarget()
    {
        if (enemiesInRange.Count == 0)
            return;

        if (disabledAtack)
            return;
            
        StartCoroutine(MultipleAttackRoutine());

        IEnumerator MultipleAttackRoutine()
        {
            while (enemiesInRange.Count != 0)
            {
                foreach (var enemy in enemiesInRange)
                {
                    var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity).GetComponent<Bullet>();
                    bullet.StartFollowTarget(enemy);
                }

                yield return new WaitForSeconds(fireRate);
            }
        }
    }

    private void Update()
    {
        // if (currentState == State.Finding)
        // {

        // }
        // else
        // {

        // }
    }

    // public void ChangeState(State state)
    //     => currentState = state;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();

        if (!enemy)
            throw new System.Exception("Tower is colliding with something that isn't enemy");

        enemiesInRange.Add(enemy);

        if (enemiesInRange.Count == 1)
        {
            // ChangeState(State.Locked);
            targetEnemy = enemy;

            if (towerKind == Kind.Single)
            {
                AtackOneTarget();
            }
            else if (towerKind == Kind.Multiple)
            {
                AtackAllTarget();
            }
        }
    }

    private Enemy FindNereastTarget()
    {
        // ! For first
        return enemiesInRange.Count == 0 ? null : enemiesInRange[0];

        // ! For nereast
        // if (enemiesInRange.Count == 0)
        //     return null;

        // var myPosition = transform.position;

        // var possibleTarget = enemiesInRange[0];
        // var lowerDist = (myPosition - possibleTarget.transform.position).magnitude;
        // for (int i = 1; i < enemiesInRange.Count; i++)
        // {
        //     var curDist = (myPosition - enemiesInRange[i].transform.position).magnitude;
        //     if (lowerDist > curDist)
        //     {
        //         possibleTarget = enemiesInRange[i];
        //         lowerDist = curDist;
        //     }
        // }

        // return possibleTarget;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var enemy = other.GetComponent<Enemy>();

        if (!enemy)
            throw new System.Exception("Tower is colliding with something that isn't enemy");

        enemiesInRange.Remove(enemy);

        if (enemy == targetEnemy)
            targetEnemy = FindNereastTarget();
    }

    // * Substituido pelo exit
    // private void RemoveEnemy(Enemy enemy)
    // {  
    //     if (!enemiesInRange.Contains(enemy))
    //         throw new System.Exception("Enemies does not exist in list");

    //     enemiesInRange.Remove(enemy);
    // }

    private void OnDrawGizmos()
    {
        Gizmos.color = wireFrameColor;
        Gizmos.DrawWireSphere(transform.position, range);

        if (enemiesInRange.Count == 0)
            return;

        Gizmos.color = Color.red;
        foreach (var enemy in enemiesInRange)
        {
            if (enemy == targetEnemy)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, enemy.transform.position);
                Gizmos.color = Color.red;
            }
            else
                Gizmos.DrawLine(transform.position, enemy.transform.position);
        }
    }
}