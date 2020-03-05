using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessManager : MonoBehaviour
{
    #region Singleton
    public static MessManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<Furniture> furniture;
}
