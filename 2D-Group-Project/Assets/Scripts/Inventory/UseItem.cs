using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    private Transform player;
    private Animator playerAnim; 

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAnim = player.GetComponent<Animator>(); 
    }

    // Update is called once per frame
   private void Update()
    {
        
    }

    public void Use()
    {
        if(gameObject.tag != "Untagged")
        playerAnim.SetBool("Use" + gameObject.tag, true);
    }
}
