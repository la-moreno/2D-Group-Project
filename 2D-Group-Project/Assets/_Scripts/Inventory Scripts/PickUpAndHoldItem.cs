using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 


////////////////FOR PICKUP AND DROP ITEM ON MOUSE CLICK////////////////////
public class PickUpAndHoldItem : MonoBehaviour
{
    public Item item;                  //Used to know what item and its properties we're picking up 
    public GameObject Player;
    public Transform Destination;      //this is the hand that holds the item
    public float pickupDistance;       //Value set by player. How close does player want to be in order to pick up the item
    float itemPlayerDistance;          //Distance between player and object
    public InventoryUI invUI;          //Used to check if player has the inventory up 
    InventorySlot[] slots;             //Slots inside inventory         
    public Transform itemsParent;      //Used to determine where the inventory slot(s) is     
    //public DropItem Ditem;
    

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
    }

    void OnMouseDown()
    {
        if (itemPlayerDistance <= pickupDistance)                           //If player is within a certain distance of object
        {
            //if (!EventSystem.current.IsPointerOverGameObject())
            if(!invUI.usingInventory)                                      //If the inventory is not open and player interacts with object, add object to inventory. 
            {

                //Ditem.StoreObj(this.gameObject);

                GetComponent<Rigidbody>().useGravity = false;              //make sure item doesn't fall out of hand
                GetComponent<Rigidbody>().isKinematic = true;              //make sure item doesn't float away from player
                this.transform.position = Destination.position;            //move object to same position as hand
                this.transform.parent = GameObject.Find("Hand").transform; //makes the object a child of the hand (destination)
                AddToInventory(); 
            }
        }
    }

    void Update()
    {
        itemPlayerDistance = Vector3.Distance(this.transform.position, Player.transform.position); //Determines distance between object and player
        //dropitem();
    }

    public void AddToInventory()
    {
        bool wasPickedUp = Inventory.instance.Add(item); //if there's space in the inventory, add the object/item to inventory

        if (wasPickedUp) 
        {
            Debug.Log(item.name + " added to inventory.");
            Destroy(gameObject);
           
        }
        else 
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
           
        }
     }

    //void dropitem()
    //{
    //    for (int i = 0; i < slots.Length; i++) //loop through all slots 
    //    {
    //        if (slots[i].droppeditem == true)
    //        {
    //            Ditem.SpawnDroppedItem(i);

    //            slots[i].droppeditem = false;
    //            Debug.Log("Dropping item");
    //            break;
    //        }
    //    }
    //}

}

















//////////////////////////CLICK LEFT MOUSE BUTTON TO GRAB OBJECT, Q TO RELEASE//////////////////////
//public class PickUpAndHoldItem : MonoBehaviour
//{
//    public GameObject Player;
//    public Transform Destination;      //this is the hand that holds the item
//    public float pickupDistance;       //Value set by player. How close does player want to be in order to pick up the item
//    float itemPlayerDistance;          //Distance between player and object
//    private int itemHeld = 0;          //Is the item being held? Set to false

//    void OnMouseDown()
//    {
//        if (itemHeld == 0 && itemPlayerDistance <= pickupDistance)
//        {
//            GetComponent<Rigidbody>().useGravity = false;              //make sure item doesn't fall out of hand
//            GetComponent<Rigidbody>().isKinematic = true;              //make sure item doesn't float away from player
//            this.transform.position = Destination.position;            //move object to same position as hand
//            this.transform.parent = GameObject.Find("Hand").transform; //makes the object a child of the hand (destination)

//            itemHeld = 1; //Item is being held
//        }
//    }

//    void Update()
//    {
//        //Determine distance between item and player
//        itemPlayerDistance = Vector3.Distance(this.transform.position, Player.transform.position); 

//        ////If item is being held and player presses key
//        //if (itemHeld == 1 && Input.GetKeyDown(KeyCode.Q))
//        //{
//        //    ////Item is released
//            //print("Released item.");
//            //this.transform.parent = null; //Hand is no longer parent to item
//            //GetComponent<Rigidbody>().useGravity = true;
//            //GetComponent<Rigidbody>().isKinematic = false;
//            //itemHeld = 0;
//        }
//    }

//}