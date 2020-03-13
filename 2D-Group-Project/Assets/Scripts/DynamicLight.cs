using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLight : MonoBehaviour
{
    const float SHADOW_LENGTH = 100.0f;

    List<Mesh> shadowMeshes;

    void Start()
    {
        shadowMeshes = new List<Mesh>();
    }

    struct ShadowPolygon
    {
        public Vector3[] points;
    }

    void Update()
    {
        ShadowPolygon shadow = new ShadowPolygon();

        for (float angle = 0.0f; angle < 360.0f; angle += 1.0f)
        {
            Vector2 rayDir = Vector2FromAngle(angle);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDir);

            if (hit.collider != null)
            {
                if(shadow.points[0] == null && shadow.points[1] == null)
                {
                    // If there is no near points, add hit point to shadow as near 1
                    shadow.points[0] = hit.point;

                    //calculate far point
                    shadow.points[3] = hit.point + (rayDir * SHADOW_LENGTH);
                }
                else if(shadow.points[0] != null && shadow.points[1] == null)
                {
                    // If there is only 1 point in shadow, add hit point to shadow as near 2
                    shadow.points[1] = hit.point;

                    //calculate far point
                    shadow.points[2] = hit.point + (rayDir * SHADOW_LENGTH);
                }
                else if (shadow.points[0] != null && shadow.points[1] != null)
                {
                    //create mesh
                    Mesh shadowMesh = new Mesh();

                    shadowMesh.vertices = shadow.points;

                    shadowMesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };

                    //add to mesh list
                    shadowMeshes.Add(shadowMesh);

                    //reset shadow
                    shadow = new ShadowPolygon();
                }
            }
        }
    }

    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
