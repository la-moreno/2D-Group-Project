using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour //Add this to each slot in the inventory
{
    private GameObject player; 
    private Inventory inventory;
    public int i;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>(); //get the inventory attached to the player
    }

    private void Update()
    {
        if (transform.childCount <= 0) //There's no item in this particular slot
        {
            inventory.isFull[i] = false;
        }
    }

    //    public void DropItem()
    //    {
    //        foreach(Transform child in transform)
    //        {
    //            child.GetComponent<SpawnItem>().SpawnDroppedItem(); 
    //            GameObject.Destroy(child.gameObject); 
    //        }
    //    }

    public void UseItem()
    {
        foreach (Transform child in transform)
        {
            

        }
    }
}
