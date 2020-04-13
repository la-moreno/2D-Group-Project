//using UnityEngine;
////using UnityStandardAssets.Characters.FirstPerson; 

//public class InventoryUI : MonoBehaviour 
//{
//    public Transform itemsParent; //Reference to parent of all inventory slots
//    public GameObject inventoryUI;
//    Inventory inventory;
//    InventorySlot[] slots;

//    // Start is called before the first frame update
//    void Start()
//    {
//        inventory = Inventory.instance;              //Reference to inventory
//        inventory.onItemChangedCallback += UpdateUI; //Trigger event whenever new item is added/removed (update)

//        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Find all inventory slot components 
//    }

//    void UpdateUI() //All the code for updating our items in the inventory. 
//    {               
  
//        //Debug.Log("UPDATING UI");

//        for (int i = 0; i < slots.Length; i++) //loop through all inventory slots
//        {
//            //For each iteration, we want to check if there are more items to add
//            if (i < inventory.items.Count) 
//            {
//                slots[i].AddItem(inventory.items[i]);
//            }

//            else //Aren't any more items to add
//            {
//                slots[i].ClearSlot();
//            }
//        }
//    }

//}
