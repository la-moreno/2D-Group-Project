using UnityEngine;
//using UnityStandardAssets.Characters.FirstPerson; 

public class InventoryUI : MonoBehaviour 
{
    public Transform itemsParent; //Reference to parent of all inventory slots
    public GameObject inventoryUI;
    Inventory inventory;
    InventorySlot[] slots;
    //public FirstPersonController player;
    //public bool usingInventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;              //Reference to inventory
        inventory.onItemChangedCallback += UpdateUI; //Trigger event whenever new item is added/removed (update)

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //Find all inventory slot components 
        //if (inventoryUI.activeSelf) //Determine if inventory is open
        //    usingInventory = true;
        //else
        //    usingInventory = false;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if(Input.GetButtonDown("Inventory"))  //Inventory opens/closes when E is pressed 
    //    {
    //        inventoryUI.SetActive(!inventoryUI.activeSelf); //Set it to its reverse state
    //        if (!inventoryUI.activeSelf) //If UI is inactive
    //        {
    //            usingInventory = false;
    //            //Player.GetComponent<CharacterController>().enabled = true;
    //            //Time.timeScale = 1;

    //           ////Default character and camera movement
    //           // player.m_WalkSpeed = 5f;
    //           // player.m_RunSpeed = 10f;
    //           // player.m_MouseLook.XSensitivity = 2f;
    //           // player.m_MouseLook.YSensitivity = 2f; 
    //        }
    //        else
    //        {
    //            usingInventory = true;
    //            //Player.GetComponent<CharacterController>().enabled = false;
    //            //Time.timeScale = 0;

    //            ////Restrict character and camera movement
    //            //player.m_WalkSpeed = 0f;
    //            //player.m_RunSpeed = 0f;
    //            //player.m_MouseLook.XSensitivity = 0f;
    //            //player.m_MouseLook.YSensitivity = 0f;
    //        }
    //    }
    //}

    void UpdateUI() //All the code for updating our items in the inventory. 
    {               

        //Debug.Log("UPDATING UI");

        
        for (int i = 0; i < slots.Length; i++) //loop through all inventory slots
        {
            //For each iteration, we want to check if there are more items to add
            if (i < inventory.items.Count) 
            {
                slots[i].AddItem(inventory.items[i]);
            }

            else //Aren't any more items to add
            {
                slots[i].ClearSlot();
            }
        }
    }

}
