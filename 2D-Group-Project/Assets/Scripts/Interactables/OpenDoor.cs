using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Text doorText = null;

    private bool isOpenDoorAllowed;
    public GameObject Player;
    private Animator anim; 

   
    // Start is called before the first frame update
    void Start()
    {
        doorText.gameObject.SetActive(false);
        anim = this.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenDoorAllowed && Input.GetKeyDown(KeyCode.E))
            InteractWithDoor(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            doorText.gameObject.SetActive(true);
            isOpenDoorAllowed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            doorText.gameObject.SetActive(false);
            isOpenDoorAllowed = false;
        }
    }

    public void InteractWithDoor()
    {
        anim.SetBool("Open", true); 



        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;

    }
}
