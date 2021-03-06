using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // Because we are working with the coords to move the enemies, we need a list of coords....or the transform of each
    // object. 
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int currentWaypoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetPathWaypoints();
        transform.position = waypoints[currentWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    
    private void Move()
    {
        if (currentWaypoint < waypoints.Count)
        {
            Vector3 nextWaypointHop = waypoints[currentWaypoint].transform.position;
            float movementSpeedInFrame = Time.deltaTime * waveConfig.GetEnemyMoveSpeed();
            transform.position = Vector2.MoveTowards(transform.position, nextWaypointHop, movementSpeedInFrame);

            if (transform.position == nextWaypointHop)
            {
                currentWaypoint++;
            }
        }
        else
        {
            //Destroy(gameObject);
            currentWaypoint = 0;
        }
    }
}
