using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    [SerializeField] GameObject deathFragment;
    [SerializeField] float fragmentSpeed = 10f;
    // Start is called before the first frame update

    public void BreakApart()
    {
        Fragment1();
        Fragment2();
        Fragment3();
        Fragment4();
        Fragment5();
    }

    private void Fragment1()
    {
        GameObject fragmentProjectile = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -fragmentSpeed);
        GameObject fragmentProjectile2 = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, fragmentSpeed);          
    }

    private void Fragment2()
    {
        GameObject fragmentProjectile = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, -fragmentSpeed);   
        GameObject fragmentProjectile2 = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, fragmentSpeed);           
    }

    private void Fragment3()
    {
        GameObject fragmentProjectile = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fragmentSpeed);            
        GameObject fragmentProjectile2 = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fragmentSpeed); 
    }

    private void Fragment4()
    {
        GameObject fragmentProjectile = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(5, -fragmentSpeed);            
        GameObject fragmentProjectile2 = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(5, fragmentSpeed); 
    }

    private void Fragment5()
    {
        GameObject fragmentProjectile = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10, -fragmentSpeed);            
        GameObject fragmentProjectile2 = Instantiate(deathFragment, transform.position, Quaternion.identity) as GameObject;
        fragmentProjectile2.GetComponent<Rigidbody2D>().velocity = new Vector2(10, fragmentSpeed);    
    }
}
