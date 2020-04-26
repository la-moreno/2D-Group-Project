using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class HotbarSelector : MonoBehaviour
{
    [HideInInspector]
    public Inventory inv;
    private RectTransform myTransform;
    public Transform itemsparent;

    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
        myTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inv != null)
        {
            Vector2 pos = new Vector2((inv.getSelectedHotbarIndex() * 100) - 248f, 2f);
            myTransform.anchoredPosition = pos;
            SelectedSlot();
        }
    }
    public string SelectedSlot()
    {
        for (int i = 0; i < itemsparent.childCount; i++)
        {
            //Debug.Log("Selector pos" + myTransform.position);
            //Debug.Log("Slot pos" + itemsparent.GetChild(i).position); 
            if (myTransform.position == itemsparent.GetChild(i).position)
            {
                if (itemsparent.GetChild(i).childCount > 0)
                {
                    //Debug.Log(itemsparent.GetChild(i).GetChild(0).tag);
                    return itemsparent.GetChild(i).GetChild(0).tag;
                }
                //itemsparent.GetChild(i).gameObject.GetComponent<Button>().OnSelect(null); 
            }
        }
        return "";
    }
}
