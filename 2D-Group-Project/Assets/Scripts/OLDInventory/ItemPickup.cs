//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI; 
//using UnityEngine.EventSystems;



//public class ItemPickup : MonoBehaviour
//{
//    [SerializeField]
//    private Text pickupText = null;

//    private bool pickUpAllowed;

//    public Item item;                  //Used to know what item and its properties we're picking up 
//    public GameObject Player;
//    InventorySlot[] slots;             //Slots inside inventory         
//    public Transform itemsParent;      //Used to determine where the inventory slot(s) is     

//    void Start()
//    {
//        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
//        pickupText.gameObject.SetActive(false);

//    }

//    void Update()
//    {
//        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
//            AddToInventory();
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.name.Equals("Player"))
//        {
//            pickupText.gameObject.SetActive(true);
//            pickUpAllowed = true;
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.name.Equals("Player"))
//        {
//            pickupText.gameObject.SetActive(false);
//            pickUpAllowed = false;
//        }
//    }

//    public void AddToInventory()
//    {
//        Inventory.instance.Add(item); //if there's space in the inventory, add the object/item to inventory

//        Debug.Log(item.name + " added to inventory.");
//        Destroy(gameObject);
//    }

//}



