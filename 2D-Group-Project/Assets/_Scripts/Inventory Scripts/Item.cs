using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

//Items that will be added to inventory
public class Item : ScriptableObject        
{
    //Store item information/properties
    new public string name = "New Item";
    public Sprite icon = null;              //Image of item
    public bool isDefaultItem = false;      //Primarily used for equipment/armor. Not necessary at this point.  
    public string itemType = "Item Type";   //What is the item? Weapon, equipment, food?
    public GameObject PhysItem;  
    

    
    public void Use() //USE THE ITEM
    {
        //use the item 
        Debug.Log("Using " + name);
    }

    public void Eat() //EAT THE ITEM
    {
        Debug.Log("Eating " + name);
    }

    public void Equip() //EQUIP THE ITEM!!1!
    {

        Debug.Log("Equipping " + name);
    }

}
