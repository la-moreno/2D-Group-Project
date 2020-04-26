using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    private HotbarSelector selector;
    private PlayerAttack player;

    [HideInInspector]
    public float dirtyValue = 0.0f;

    Material material;
    MessManager messManager;
    void Start()
    {
        selector = GameObject.Find("Selector").GetComponent<HotbarSelector>();
        player = GameObject.Find("Player").GetComponent<PlayerAttack>();

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
        if (selector.SelectedSlot() == "Duster" && player.attacking)
        {
            dirtyValue -= 0.1f;

            Debug.Log("hit");
        }
    }
}
