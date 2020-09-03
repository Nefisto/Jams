using UnityEngine;

public partial class Enemy
{
    public void TakeDamage(int dmg)
    {
        status.life -= dmg;

        if (status.life < 0)
            Die();
    }

    private void Die(bool giveDamage = false)
    {
        Destroy(gameObject);

        if (giveDamage)
            loseLifeEvent.Raise(status.damage);
    }
}