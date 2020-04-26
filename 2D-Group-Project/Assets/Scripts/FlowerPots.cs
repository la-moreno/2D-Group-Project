using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPots : MonoBehaviour
{
    private HotbarSelector selector;
    private PlayerAttack player; 
    // Start is called before the first frame update
    void Start()
    {
        selector = GameObject.Find("Selector").GetComponent<HotbarSelector>();
        player = GameObject.Find("Player").GetComponent<PlayerAttack>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (selector.SelectedSlot() == "Broom" && player.attacking)
            Destroy(gameObject); 
    }
}
