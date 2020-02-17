using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float MOVEMENT_BASE_SPEED = 1.0f;

    public Transform target;
    float speed = 3f;
    Vector2[] path;
    int targetIndex;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetIndex = 0;
            PathRequestManager.RequestPath(transform.position, mousePos, OnPathFound);
        }
    }

    public void OnPathFound(Vector2[] newPath, bool pathSuccessful)
    {
        if(pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector2 currentWaypoint = path[0];
        while(true)
        {
            if((Vector2)transform.position == currentWaypoint)
            {
                targetIndex++;
                if(targetIndex >= path.Length)
                {
                    targetIndex = 0;
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            //Vector2 movementDirection = (currentWaypoint - (Vector2)transform.position).normalized;
            //float movementSpeed = 250.0f;

            //rb.AddForce(movementDirection * movementSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public void OnDrawGizmos()
    {
        if(path != null)
        {
            for(int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                //Gizmos.DrawCube(path[i], Vector2.one);

                if (i == targetIndex)
                    Gizmos.DrawLine(transform.position, path[i]);
                else
                    Gizmos.DrawLine(path[i - 1], path[i]);
            }
        }
    }
}
