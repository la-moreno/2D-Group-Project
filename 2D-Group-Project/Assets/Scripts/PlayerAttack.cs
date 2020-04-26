using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [HideInInspector]
    public bool attacking = false;

    private float attackTimer = 0;

    private float attackCoolDown = 0.35f;

    public Collider2D attackTrigger;

    private Animator anim;

    private Inventory inventory;

    private HotbarSelector selector;

    enum MyEnum
    {
        Broom,
        Duster
    }

    //called at the start
    void Awake()
    {
        //Disable collider
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        selector = GameObject.Find("Selector").GetComponent<HotbarSelector>();

    }

    // Update is called once per frame
    void Update()
    {
        //If key pressed and not attacking
        if (Input.GetKeyDown(KeyCode.Space) && !attacking)                           //original         if(Input.GetKeyDown(KeyCode.F) && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;


            for (int i = 0; i < selector.itemsparent.childCount; i++)
            {
                if (selector.itemsparent.GetChild(i).childCount > 0 && selector.SelectedSlot() != "")
                    FindObjectOfType<AudioManger>().Play("Cleaning", 0.1f);
                //if (selector.SelectedSlot() == "")      
            }

            attackTrigger.enabled = true;
            Debug.Log("attacking");
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        UseItem();

        //FindObjectOfType<AudioManger>().Play("Cleaning", 0.1f); //check
        //anim.SetBool("Use"+ selector.SelectedSlot(), attacking);

    }

    private void UseItem()
    {
        if (selector.SelectedSlot() != "")
        {
            if (anim.GetBool("Use" + MyEnum.Broom) == false || anim.GetBool("Use" + MyEnum.Duster) == false)
                anim.SetBool("Use" + selector.SelectedSlot(), attacking);

            else if (anim.GetBool("Use" + MyEnum.Broom) == true || anim.GetBool("Use" + MyEnum.Duster) == true)
            {
                anim.SetBool("Use" + MyEnum.Broom, false);
                anim.SetBool("Use" + MyEnum.Duster, false);
            }

        }
        if (selector.SelectedSlot() == "" && attacking)
        {
            attackTrigger.enabled = false;
            attacking = false;
            //if (anim.GetBool("Use" + MyEnum.Broom) == true)
            anim.SetBool("Use" + MyEnum.Broom, false);
            //if (anim.GetBool("Use" + MyEnum.Duster) == true)
            anim.SetBool("Use" + MyEnum.Duster, false);

            
        }
    }
}
