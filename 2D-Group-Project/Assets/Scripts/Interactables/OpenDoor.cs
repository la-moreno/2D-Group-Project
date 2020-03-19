using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    private Text openText = null;

    public bool isOpenDoorAllowed;
    public GameObject Player;
    private Animator anim; 

   
    // Start is called before the first frame update
    void Start()
    {
        openText.gameObject.SetActive(false);
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
            openText.gameObject.SetActive(true);
            isOpenDoorAllowed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            openText.gameObject.SetActive(false);
            isOpenDoorAllowed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            openText.gameObject.SetActive(true);
            isOpenDoorAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            openText.gameObject.SetActive(false);
            isOpenDoorAllowed = false;
        }
    }

    public void InteractWithDoor()
    {
        if (anim.GetBool("Open") == true)
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
            anim.SetBool("Open", false);
        }
           
        else
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            anim.SetBool("Open", true);
            openText.gameObject.SetActive(false); 
        }
          

        //this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;

    }
}
