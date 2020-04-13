//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    #region Singleton
//    //Used so we can have a reference to the Inventory script and ensure we only have one inventory at all times.
//    public static Inventory instance; 
    
//    void Awake()
//    {
//        if (instance != null)
//        {
//            Debug.LogWarning("More than one instance of Inventory found!");
//            return; 
//        }
//        instance = this; 
//     }
//    #endregion 

//    public delegate void OnItemChanged();       
//    public OnItemChanged onItemChangedCallback; //Whenever something is changed on the inventory, this is triggered.

//    public int space = 10;                      //How many slots/items the inventory can hold 

//    public List<Item> items = new List<Item>(); //Holds the items' info that was picked up

//    //Returns true if item was added to inventory
//    public bool Add (Item item)
//    {
//            //When trying to add a new item to inventory, check to see if we have space
//            if (items.Count >= space ) 
//            {
//                Debug.Log("Not enough room."); 
//                    return false; 
//            }
//            //If we do have space, add item to list of items in inventory
//            items.Add(item);

//            if(onItemChangedCallback != null)
//            onItemChangedCallback.Invoke(); //Triggering the event. Want UI to update 
//        return true; 
//    }

//    public void Remove (Item item )
//    {
//        items.Remove(item);
        
       
//        if (onItemChangedCallback != null)
//            onItemChangedCallback.Invoke(); //Triggering the event. Want UI to update 
//    }

//}
