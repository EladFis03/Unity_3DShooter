using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    // adding the SFX to health/death
    [Tooltip("FX prefab on enemy")] [SerializeField] GameObject deathSfx;
    [Tooltip("where to send the used SFX after that enemy died")] [SerializeField] Transform parent;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    // create a public method which reduces hitpoints by amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();

        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GameObject SFX = Instantiate(deathSfx, transform.position, Quaternion.identity);
        SFX.transform.parent = parent;
        GetComponent<Animator>().SetTrigger("Die");
    }

}
