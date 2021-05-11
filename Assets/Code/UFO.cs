using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] float health = 1000;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float enemyFireSpeed = 10f;
    [SerializeField] GameObject enemyFire;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 1f;
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
            // Fire1();
            // Fire2();
            // Fire3();
            // Fire4();
            // Fire5();
            // ShotCounter();
        }
    }

    private void Fire1()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, -enemyFireSpeed);
        GameObject enemyFireProjectile2 = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, enemyFireSpeed);          
    }

    private void Fire2()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -enemyFireSpeed);   
        GameObject enemyFireProjectile2 = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, enemyFireSpeed);           
    }

    private void Fire3()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyFireSpeed);            
        GameObject enemyFireProjectile2 = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, enemyFireSpeed); 
    }

    private void Fire4()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10, -enemyFireSpeed);            
        GameObject enemyFireProjectile2 = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(10, enemyFireSpeed); 
    }

    private void Fire5()
    {
        GameObject enemyFireProjectile = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(20, -enemyFireSpeed);            
        GameObject enemyFireProjectile2 = Instantiate(enemyFire, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(20, enemyFireSpeed);    
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
        }
    }

}
