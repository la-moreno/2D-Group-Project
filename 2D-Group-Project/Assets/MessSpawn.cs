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
       if(NumOfMesses <= 6)
        {
            int Index = MessNumb();
            switch (Index)
            {
                case 0:
                    {
                        Instantiate(Messes[Index], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }
                case 1:
                    {
                        Instantiate(Messes[Index], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }
                case 2:
                    {
                        Instantiate(Messes[Index], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }
                case 3:
                    {
                        Instantiate(Messes[Index], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }

                case 4:
                    {
                        Instantiate(Messes[Index], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }

                case 5:
                    {
                        Instantiate(Messes[MessNumb()], RandomMessPos(), Quaternion.identity);
                        NumOfMesses++;
                        break;
                    }
                default:
                    break;
            }
        }
     
    }

    Vector3 RandomMessPos()
    {
        Vector3 MessSpawnPoint = new Vector3(transform.position.x, transform.position.y, 0);
        return MessSpawnPoint; 
    }
     
    int MessNumb()
    {
       int MessNumber = Random.Range(0 , 5);
       return MessNumber; 
    }
}
