using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [SerializeField] float dropCounter;
    [SerializeField] float minTimeBetweenDrops = 1f;
    [SerializeField] float maxTimeBetweenDrops = 3f;
    [SerializeField] float healthDropSpeed = 10f;
    [SerializeField] GameObject healthItem;
    
    // Start is called before the first frame update
    void Start()
    {
        ShotCounter();
    }

    private void ShotCounter()
    {
        dropCounter = Random.Range(minTimeBetweenDrops, maxTimeBetweenDrops);
    }

    // Update is called once per frame
    void Update()
    {
        dropCounter -= Time.deltaTime;

        if (dropCounter <= 0f)
        {
            HealthAway();
            ShotCounter();
        }
    }

    private void HealthAway()
    {
        GameObject enemyFireProjectile = Instantiate(healthItem, transform.position, Quaternion.identity) as GameObject;
        enemyFireProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -healthDropSpeed);
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
        }
    }
}
