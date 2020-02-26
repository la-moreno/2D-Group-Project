using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    enum MonsterState
    {
        wander,
        pursue
    }
    MonsterState state;

    public Transform target;
    public float speed = 200;
    public float nextWaypointDistance = 3f;

    public Transform enemyGFX;
    public Animator animator;

    Path path; // current path we are following 
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;


    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //InvokeRepeating("UpdatePath", 0f, 3f);
        state = MonsterState.wander;
    }

    void Update()
    {
        switch (state)
        {
            case MonsterState.wander:
                StartCoroutine(Wander(1.0f));
                break;
        }
    }

    IEnumerator Wander(float interval)
    {
        while (state == MonsterState.wander)
        {
            if (path != null)
            {
                if (currentWaypoint == path.vectorPath.Count - 1)
                    StartCoroutine(UpdatePath(3.0f));
            }
            else
                StartCoroutine(UpdatePath(1.0f));

            yield return new WaitForSeconds(0.0f);
        }
    }

    IEnumerator UpdatePath(float interval)
    {
        yield return new WaitForSeconds(interval);
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

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
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
            reachedEndOfPath = false;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

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
