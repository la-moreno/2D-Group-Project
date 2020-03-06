using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessManager : MonoBehaviour
{
    bool roundstart = true;

    #region Singleton
    public static MessManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Furniture> furniture;

    private void Update()
    {
        if(roundstart == true)
        {
            for(int f = 0; f < furniture.Count; f++)
            {
                bool willMess = (Random.value > 0.5f);
                if (willMess == true)
                    furniture[f].dirtyValue = 0.4f;
                else
                    furniture[f].dirtyValue = 0.0f;

            }
            roundstart = false;
        }
    }
}
