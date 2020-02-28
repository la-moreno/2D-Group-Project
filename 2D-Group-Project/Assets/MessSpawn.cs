using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Joel's Randoms Messes Spawner 

public class MessSpawn : MonoBehaviour
{
    public int NumOfMesses;
    public GameObject[] Messes;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("RandomMessPos", 10.0f, 10.0f );
    }

    void RandomMessPos()
    {
        Vector3 MessSpawnPoint = new Vector3(transform.position.x, transform.position.y, 0);
        

        if (NumOfMesses <= 6)
        {
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


    }

    int MessNumb()
    {
       int MessNumber = Random.Range(0 , 5);
       return MessNumber; 
    }
}
