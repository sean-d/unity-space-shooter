using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int killValue = 10;

    [Header("Weaponry")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float enemyFireSpeed = 10f;

    [SerializeField] GameObject enemyFire;
    
    [Header("EFFECTS")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float volumeDeathSFX = .5f;
    //[SerializeField] AudioClip shootSFX;
    //[SerializeField] float volumeShootSFX = .5f;
    // Start is called before the first frame update
    void Start()
    {
        ShotCounter();
    }

    private void ShotCounter()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            Fire();
            ShotCounter();
        }
    }

    private void Fire()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyFireSpeed);
        //AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position, volumeShootSFX);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) { return; } //if the object colliding with this has no damage dealer, protect against null ref errors.
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
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
