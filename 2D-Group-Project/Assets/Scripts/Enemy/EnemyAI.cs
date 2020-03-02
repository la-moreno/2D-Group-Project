using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class EnemyAI : MonoBehaviour
{
    public const float DETECTION_RADIUS = 5.0f;

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
    public float nextWaypointDistance = 0.05f;

    bool playerFound = false;

    // Transform of animated object for monster
    public Transform enemyGFX;  

    Path path; // current path we are following 

    // Variables for pathfinding
    int currentWaypoint = 0;
    bool reachedEndOfPath = true;

    //Variables for audio
    float stepInterval = 0.6f;
    float stepTime = 0.0f;

    Seeker seeker;
    Rigidbody2D rb;
    AudioManger audioManger;
    void Start()
    {
        audioManger = AudioManger.instance;
        
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        
        //Initialize behaviors
        currentState = MonsterState.idle;
        state = MonsterState.pursue_player;
    }

    void Update()
    {
        Vector2 ToPlayer = player.position - transform.position;

        if (playerFound == false)
        {
            // Pursure player if within the detection radius
            if (ToPlayer.magnitude <= DETECTION_RADIUS)
            {
                state = MonsterState.pursue_player;
                playerFound = true;
            }
            else
                state = MonsterState.wander;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ToPlayer.normalized, 1000f, LayerMask.NameToLayer("Default"));
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player Lost");
                    playerFound = false;
                    state = MonsterState.wander;
                }
            }
        }

        // Play footsteps (volume based on distance from player)
        if(stepTime < Time.time)
        {
            if (ToPlayer.magnitude < 15.0f)
            {
                // Convert distance to value between 0 and 1 for volume
                float volume = Mathf.Clamp01(0.2f / ToPlayer.magnitude);
                Debug.Log(volume);

                // Play monster footstep sound
                audioManger.Play("Monster_Footsteps", volume);
            }
            stepTime = Time.time + stepInterval;
        }

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
