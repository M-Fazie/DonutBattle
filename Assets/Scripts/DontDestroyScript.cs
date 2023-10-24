using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DontDestroyScript : MonoBehaviour
{
    
    private static DontDestroyScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

    }
}
