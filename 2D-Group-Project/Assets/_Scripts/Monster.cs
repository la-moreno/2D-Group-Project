using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float movementSpeed;
    bool isMoving = false;

    Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        StartCoroutine(EnemyMovement());
    }

    IEnumerator EnemyMovement()
    {
        while (true)
        {
            while (isMoving == false)
            {
                yield return new WaitForSeconds(2.0f);
                StartCoroutine(FindPosition());
            }

            yield return new WaitForSeconds(0.0f);
        }
    }

    IEnumerator FindPosition()
    {
        isMoving = true;
        bool foundPosition = false;

        while (foundPosition == false)
        {
            Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));

            // Get random position
            //Vector2 newRandPos = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            //Vector2 toNewPosition = (newRandPos - (Vector2)transform.position);

            //Send ray to check for wall collision
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1000.0f, LayerMask.NameToLayer("Default"));
            if (hit.collider != null)
                Debug.Log("hit");

            if (hit.distance >= 8.0f)
            {
                foundPosition = true;
                float distance = Random.Range(6.0f, hit.distance - 2.0f);
                StartCoroutine(MoveToPosition(dir, (Vector2)transform.position + (dir * distance)));
            }

            yield return new WaitForSeconds(0.0f);
        }
    }

    IEnumerator MoveToPosition(Vector2 dir, Vector2 target)
    {
        while (Vector2.Distance(transform.position, target) >= 1.0f)
        {
            rigidbody2D.velocity = dir * movementSpeed;

            yield return new WaitForSeconds(0.0f);
        }

        StartCoroutine(SlowToStop());
        isMoving = false;
    }

    IEnumerator SlowToStop()
    {
        while (rigidbody2D.velocity.magnitude > 0)
        {
            rigidbody2D.velocity = rigidbody2D.velocity * 0.8f;
            yield return new WaitForSeconds(0.0f);
        }
        Debug.Log("Stopped");
    }
}
