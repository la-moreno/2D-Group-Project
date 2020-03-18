using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InteractWithObject : MonoBehaviour
{
    [SerializeField]
    private Text openText = null;

    private bool isOpenDoorAllowed;
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
            Interact();
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

    public void Interact()
    {
        if (anim.GetBool("Open") == true)
            anim.SetBool("Open", false);
        else
            anim.SetBool("Open", true);



        //this.gameObject.GetComponent<Collider2D>().enabled = false;
        //this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;

    }
}
