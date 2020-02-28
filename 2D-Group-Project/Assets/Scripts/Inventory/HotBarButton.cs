using System;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;
//using UnityEngine.EventSystems; 

public class HotBarButton : MonoBehaviour
{
    public event Action<int> OnButtonClicked;

    private KeyCode keyCode;
    private int keyNumber;
    public InventorySlot slot;
    private int selectedHotbarIndex = 0;
    private float scrollNumber;
    

    private void OnValidate()
    {

        keyNumber = transform.GetSiblingIndex() + 1;
        keyCode = KeyCode.Alpha0 + keyNumber;
        
         
        slot = this.GetComponent<InventorySlot>(); 
    }
 
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(HandleClick); 
    }

    private void Update()
    {
        //UpdateSelectedHotbarIndex(scrollNumber);
        //Debug.Log(GetSelectedHotbarIndex());
        //if(Input.GetAxis("Mouse ScrollWheel") > 0 )
        //{

        //}

        if (Input.GetKeyDown(keyCode))
        {
            HandleClick(); 
        }


        //for (int i = 0; i < 9; i++)
        //{
        //    if (Input.GetKeyDown(hotbarControls[i]))
        //    {
        //        selectedHotbarIndex = i;
        //    }
        //}
    }

    private void HandleClick()
    {
        if (OnButtonClicked != null)
            OnButtonClicked.Invoke(keyNumber);
        slot.UseItem();
        GetComponent<Button>().Select();
        
        //StartCoroutine(Wait());
        //EventSystem.current.SetSelectedGameObject(null);
    }

    private void UpdateSelectedHotbarIndex(float direction)
    {
        if (direction > 0)
            direction = 1;

        if (direction < 0)
            direction = -1;

        for (selectedHotbarIndex -= (int)direction; selectedHotbarIndex < 0; selectedHotbarIndex += 9) ;
        //selectedHotbarIndex = keyNumber; 

        while (selectedHotbarIndex >= 9)
            selectedHotbarIndex -= 9;
    }

    public int GetSelectedHotbarIndex()
    {
        return selectedHotbarIndex;
    }

    //private IEnumerator Wait()
    //{
    //    yield return new WaitForSeconds(5);
    //}
}
