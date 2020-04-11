using UnityEngine;

[ExecuteInEditMode]
public class Depth : MonoBehaviour
{

    void Update()
    {
        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -100);
    }


}