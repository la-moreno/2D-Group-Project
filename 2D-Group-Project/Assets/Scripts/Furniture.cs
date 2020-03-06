using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [HideInInspector]
    public float dirtyValue = 0.0f;

    Material material;
    MessManager messManager;
    void Start()
    {
        messManager = MessManager.Instance;
        material = GetComponent<SpriteRenderer>().material;

        // Add to list of furniture
        messManager.furniture.Add(this);
    }

    private void Update()
    {
        material.SetFloat("_DirtyValue", dirtyValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
    }
}
