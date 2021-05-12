using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int killValue = 10;

    
    [Header("EFFECTS")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float volumeDeathSFX = .5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer) //if the object colliding with this has no damage dealer, protect against null ref errors.
        { 
            Debug.Log(damageDealer);
            ProcessHit(damageDealer);
        } else
        {
            return;
        }


    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        Debug.Log(damageDealer.GetDamage());
        health -= damageDealer.GetDamage();
        damageDealer.Hit(); //removes projectile

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die() {
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfDeath);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, volumeDeathSFX);
            FindObjectOfType<GameSession>().AddToScore(killValue);
        }
    }
}
