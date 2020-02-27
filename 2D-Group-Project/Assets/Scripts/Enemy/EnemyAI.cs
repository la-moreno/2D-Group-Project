using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    enum MonsterState
    {
        idle,
        wander,
        pursue_player
    }

    MonsterState state;
    MonsterState currentState;

    public Transform player;
    public float speed = 200;
    public float nextWaypointDistance = 3f;

    // Transform of animated object for monster
    public Transform enemyGFX;  

    Path path; // current path we are following 

    // Variables for pathfinding
    int currentWaypoint = 0;
    bool reachedEndOfPath = true;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        //Initialize behaviors
        currentState = MonsterState.idle;
        state = MonsterState.pursue_player;
    }

    void Update()
    {
        // Switch to new state if the state has changed
        if (state != currentState)
        {
            currentState = state;
            switch (state)
            {
                case MonsterState.wander:
                    StartCoroutine(Wander(1.0f));
                    break;
                case MonsterState.pursue_player:
                    StartCoroutine(Pursue(0.5f, player));
                    break;
            }
        }
    }

    // Wanders randomly around the map
    IEnumerator Wander(float interval)
    {
        Vector2 randPosition;

        while (state == MonsterState.wander)
        {
            if (reachedEndOfPath == true)
            {
                randPosition = new Vector2(Random.Range(-40f, 40f), Random.Range(-40f, 40f));

                yield return new WaitForSeconds(interval);
                UpdatePath(randPosition);
            }
            yield return new WaitForSeconds(0.0f);
        }
    }

    // Pursues the given target
    IEnumerator Pursue(float interval, Transform target)
    {
        while (state == MonsterState.pursue_player)
        {
            UpdatePath(target.position);

            yield return new WaitForSeconds(interval);
        }
    }

    // Find a path
    void UpdatePath(Vector3 destination)
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, destination, OnPathComplete);
        Debug.Log("Path started");
    }

    // Set found path as current path
    void OnPathComplete(Path p)
    {
        // Make sure there were no errors finding a path
        if (!p.error)
        {
            //Set path as our current path
            path = p;
            currentWaypoint = 0;
        }
        
    }

    void FixedUpdate()
    {
        MonsterMovement();
    }

    // Move along the path
    void MonsterMovement()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
            reachedEndOfPath = false;
        
        // Add a force in the direction of the current waypoint
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        // Increment to the next waypoint when we reach the current one
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
            currentWaypoint++;

        // Flip sprite to match velocity
        if (rb.velocity.x >= 0.1f)
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        else if (rb.velocity.x <= -0.1f)
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
    }
}
