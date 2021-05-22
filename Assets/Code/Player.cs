using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PLayer")]
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float health = 200f;

    [Header("Weapon")]
    [SerializeField] GameObject playerBlueLazer;
    [SerializeField] float playerLazerSpeed = 20.0f;
    [SerializeField] float playerShotTimeBeweenShots = 0.1f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfDeath = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float volumeDeathSFX = .5f;
    [SerializeField] HealthBar healthBar;

    Coroutine KBFiringCoroutine;
    Coroutine GamePadFiringCoroutine;

    // Boundaries for player movement on the board
    float playerXMin;
    float playerXMax;
    float playerYMin;
    float playerYMax;
    float playerWidth;
    float playerHeight;
    float xPos, yPos;
    float maxHealth = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerBoundaries();
        GetPlayerSize();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PlayerShoot();
        healthBar.UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.transform.name == "Player Health Boost")
        // {
        //     health += 100;
        // }

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) { return; } //if the object colliding with this has no damage dealer, protect against null ref errors.
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        
        // to ensure the health drops don't push the player health above the max.
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthBar.UpdateHealthBar();
        if (damageDealer.transform.name != "METEOR(Clone)") // this way the meteor is not nuked when it touches the player
        {
            damageDealer.Hit(); //removes projectile
        }

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
            FindObjectOfType<LevelControl>().EndGame();
        }
    }

    private void PlayerShoot()
    {
        KBFire();
        GamePadFire();

    }

    public float GetPlayerHealth()
    {
        return health;
    }

    public float GetPlayerMaxHealth()
    {
        return maxHealth;
    }

    private void KBFire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            KBFiringCoroutine = StartCoroutine(ShootContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(KBFiringCoroutine);
        }
    }

    private void GamePadFire()
    {
        if (Input.GetButtonDown("PadFire"))
        {
            GamePadFiringCoroutine = StartCoroutine(ShootContinuously());
        }
        if (Input.GetButtonUp("PadFire"))
        {
            StopCoroutine(GamePadFiringCoroutine);
        }
    }

    IEnumerator ShootContinuously()
    {
        while (true) 
        {
            GameObject playerLazer = Instantiate(playerBlueLazer, transform.position, Quaternion.identity) as GameObject;
            playerLazer.GetComponent<Rigidbody2D>().velocity = new Vector2(0, playerLazerSpeed);

            yield return new WaitForSeconds(playerShotTimeBeweenShots);
        }
    }

    private void Move()
    {
        float getXPos = transform.position.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        xPos = Input.GetAxisRaw("Horizontal");
        float getYPos = transform.position.y + Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        yPos = Input.GetAxisRaw("Vertical");

        float newXPos = Mathf.Clamp(getXPos, playerXMin + playerWidth, playerXMax - playerWidth);
        float newYPos = Mathf.Clamp(getYPos, playerYMin + playerHeight, playerYMax - playerHeight);


        transform.position = new Vector2(newXPos, newYPos);
    }

    public float GetYPos()
    {
        return yPos;
    }

    public float GetXPos()
    {
        return xPos;
    }

    private void GetPlayerSize()
    {
        // used to establish padding. this way no matter what size the player is, the padding will be correct.
        // half the size of the ship means the nose, wings, and tail will touch the boundaries and not extend.
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    private void SetPlayerBoundaries()
    {
        Camera gameCamera = Camera.main;
        
        playerXMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        playerXMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;

        playerYMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        playerYMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y;

    }

}
