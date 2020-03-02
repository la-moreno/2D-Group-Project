using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Joel's Randoms Messes Spawner 

public class MessSpawn : MonoBehaviour
{
    public int NumOfMesses;
    public GameObject[] Messes;
    public float waitTime = 5.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime && NumOfMesses <= 6)
        {
            RandomMessPos();
            timer = timer - waitTime;
        }

    }

    void RandomMessPos()
    {
        Vector3 MessSpawnPoint = new Vector3(transform.position.x, transform.position.y, 0);



        int Index = MessNumb();
        switch (Index)
        {
            case 0:
                {
                    Instantiate(Messes[Index], MessSpawnPoint, Quaternion.identity);
                    NumOfMesses++;
                    return;
                }
            case 1:
                {
                    Instantiate(Messes[Index], MessSpawnPoint, Quaternion.identity);
                    NumOfMesses++;
                    return;
                }
            case 2:
                {
                    Instantiate(Messes[Index], MessSpawnPoint, Quaternion.identity);
                    NumOfMesses++;
                    return;
                }

            default:
                break;
        }
    }

    int MessNumb()
    {
        int MessNumber = Random.Range(0, 5);
        return MessNumber;
    }
}
