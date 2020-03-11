using UnityEngine;
using UnityEngine.UI;
 
//Keep track of everything that is happening on a particular slot
//This will update the UI on the slot and the functions that happens
//when we press it or press remove. 
public class InventorySlot : MonoBehaviour
{
    public Image icon; //reference to the image component on the icon object
    //public Button removeButton; 
    public Item item; //Keep track of the current item of the slot 


    public void AddItem(Item newItem) //Add item to the slot
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        //removeButton.interactable = true; //When we add an item, remove button can now be pressed 
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false; 

    }

    public void onRemoveButton() //Called whenever Remove button is pressed
    {
        //Drop item here 
        Inventory.instance.Remove(item);          
    }

    public void UseItem() //Have a way to use an item
    {
        //Check if we actually have an item
        if(item != null)
        {
                item.Use(); 
        }
    }

}
