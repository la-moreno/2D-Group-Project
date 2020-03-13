using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

//Items that will be added to inventory
public class Item : ScriptableObject        
{
    //Store item information/properties
    new public string name = "New Item";
    public Sprite icon = null;              //Image of item
    public string itemType = "Item Type";   //What is the item? Weapon, equipment, food?  
    
    public void Use() //USE THE ITEM
    {
        //use the item 
        Debug.Log("Using " + name);
    }



}
