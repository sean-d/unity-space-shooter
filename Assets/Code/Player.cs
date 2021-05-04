using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float newXPos = transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newYPos = transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.position = new Vector2(newXPos, newYPos);
    }
}
