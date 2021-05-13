using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recycler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.name == "Left Meteor(Clone)")
        {
            return;
        } 

        else if (other.transform.name == "Right Meteor(Clone)")
        {
            return;
        } 
        else
        {
            Destroy(other.gameObject);
        }
    }
}
