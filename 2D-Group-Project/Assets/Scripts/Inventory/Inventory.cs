using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour //Add this to player
{
    //public int Numslots; 
    public bool[] isFull;       //check if slots in inventory are full 
    
    public GameObject[] slots;  //slots of the inventory
    private int selectedHotbarIndex; 

    private void Start()
    {
        //Numslots = slots.Length; 
    }


    private void Update()
    {
        updateSelectedHotbarIndex(Input.GetAxis("Mouse ScrollWheel"));
        //Debug.Log(slots.Length);
    }


    private void updateSelectedHotbarIndex(float direction)
    {
        if (direction > 0)
            direction = 1;
        if (direction < 0)
            direction = -1;

        for (selectedHotbarIndex -= (int)direction; selectedHotbarIndex < 0; selectedHotbarIndex += 6) ;
        while (selectedHotbarIndex >= 6)
            selectedHotbarIndex -= 6;

        //Debug.Log(selectedHotbarIndex);
    }

    public int getSelectedHotbarIndex()
    {
        return selectedHotbarIndex; 
    }
}
