using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] GameObject playerBlueLazer;
    [SerializeField] float playerLazerSpeed = 20.0f;
    [SerializeField] float playerShotTimeBeweenShots = 0.1f;

    Coroutine KBFiringCoroutine;
    Coroutine GamePadFiringCoroutine;
    // Boundaries for player movement on the board
    float playerXMin;
    float playerXMax;
    float playerYMin;
    float playerYMax;
    float playerWidth;
    float playerHeight;

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
    }
    private void PlayerShoot()
    {
        KBFire();
        GamePadFire();

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
        float getXPos = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float getYPos = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newXPos = Mathf.Clamp(getXPos, playerXMin + playerWidth, playerXMax - playerWidth);
        float newYPos = Mathf.Clamp(getYPos, playerYMin + playerHeight, playerYMax - playerHeight);

        transform.position = new Vector2(newXPos, newYPos);
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
