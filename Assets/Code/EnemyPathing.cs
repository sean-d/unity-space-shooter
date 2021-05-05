using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Because we are working with the coords to move the enemies, we need a list of coords....or the transform of each
    // object. 
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int currentWaypoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {
        if (currentWaypoint < waypoints.Count)
        {
            Vector3 nextWaypointHop = waypoints[currentWaypoint].transform.position;
            float movementSpeedInFrame = Time.deltaTime * moveSpeed;
            transform.position = Vector2.MoveTowards(transform.position, nextWaypointHop, movementSpeedInFrame);

            if (transform.position == nextWaypointHop)
            {
                currentWaypoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
