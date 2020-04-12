using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemPickup : MonoBehaviour //Add this to each tool you want to pick up 
{
    private Inventory inventory;
    public GameObject itemButton; //item inside the slot
    [SerializeField]
    private Text pickupText = null; //Text that shows up when near a tool
    private bool pickupAllowed; //is true when the player is inside the tool's collider

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //get the inventory attached to the player 
        pickupText.gameObject.SetActive(false);
    }

    private void Update()
    {
       if (Input.GetKey(KeyCode.E) && pickupAllowed)
        {
            AddToInventory(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other) //If player collides with object, he's allowed to pickup the item. 
    {
        if (other.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(true);
            pickupAllowed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) //Player no longer allowed to pickup the item.
    {
        if (other.gameObject.name.Equals("Player"))
        {
            pickupText.gameObject.SetActive(false);
            pickupAllowed = false;
        }
    }

    void AddToInventory()
    {
        for (int i = 0; i < inventory.slots.Length; i++) //iterate through all slots in inventory
        {
            if (inventory.isFull[i] == false) //Check if the slot[i] of the inventory is full 
            {
                //item can be added 
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false); //Item's icon will be placed in the slot[i]
                //if (inventory.slots[i].tag != "Untagged" && inventory.slots[i].tag != "Health Potion")
                //player.GetComponent<Animator>().SetBool(gameObject.tag, true);
                Destroy(gameObject); //destroy item you picked up. 

                break;
            }
        }
    }
}
