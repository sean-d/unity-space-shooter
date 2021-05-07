using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float enemyFireSpeed = 10f;
    [SerializeField] GameObject enemyFire;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
